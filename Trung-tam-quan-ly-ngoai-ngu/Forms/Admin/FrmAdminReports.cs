using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminReports : Form
{
    private static readonly CultureInfo ReportCulture = CultureInfo.GetCultureInfo("vi-VN");

    private readonly ILanguageCenterDataService _dataService;
    private ReportScenario? _currentScenario;
    private bool _initialReportLoaded;

    public FrmAdminReports() : this(AppRuntime.DataService)
    {
    }

    public FrmAdminReports(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;

        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Báo cáo thống kê");
        ApplyLocalizedText();
        ConfigureVisualStyle();
        ConfigureChartSurface();
        ConfigureScrollableLayout();
        FormHostHelpers.EnableAdaptiveScrolling(this);
        BindReportEvents();
        Shown += (_, _) => EnsureDefaultReportLoaded();
        Resize += (_, _) => ApplyResponsiveLayout();
        pnlAdminReportTitleBlock.Resize += (_, _) => LayoutReportTitleBlock();
        pnlReportHighlightCard.Resize += (_, _) => LayoutHighlightCard();
        pnlReportDistributionCard.Resize += (_, _) => LayoutDistributionCard();
        pnlReportChartHeader.Resize += (_, _) => LayoutChartHeader();
        pnlReportDetailHeader.Resize += (_, _) => LayoutDetailHeader();
    }

    private void ConfigureScrollableLayout()
    {
        AutoScroll = true;
        AutoScrollMinSize = FormHostHelpers.ScaleSize(this, new Size(0, 1220));

        tblAdminReportRoot.SuspendLayout();
        tblAdminReportRoot.Dock = DockStyle.Top;
        tblAdminReportRoot.AutoScroll = false;
        tblAdminReportRoot.AutoSize = false;
        tblAdminReportRoot.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        tblAdminReportRoot.RowStyles[0] = new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 118));
        tblAdminReportRoot.RowStyles[1] = new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 140));
        tblAdminReportRoot.RowStyles[2] = new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 170));
        tblAdminReportRoot.RowStyles[3] = new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 460));
        tblAdminReportRoot.RowStyles[4] = new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 330));
        tblAdminReportRoot.ResumeLayout(true);

        tblAdminReportFilter.SuspendLayout();
        tblAdminReportFilter.ColumnCount = 4;
        tblAdminReportFilter.ColumnStyles.Clear();
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        btnViewReport.Dock = DockStyle.Fill;
        btnViewReport.MinimumSize = new Size(170, 0);
        tblAdminReportFilter.ResumeLayout(true);

        tblReportMiddle.Dock = DockStyle.Fill;
        tblReportMiddle.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(0, 460));

        pnlReportChartCard.Dock = DockStyle.Fill;
        pnlReportChartCard.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(700, 460));
        pnlReportChartHeader.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(0, 54));
        chtAdminRevenue.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(0, 260));
        pnlReportHighlightCard.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(0, 260));
        pnlReportDistributionCard.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(0, 180));

        foreach (var panel in new[]
        {
            pnlReportRevenueAccent,
            pnlReportEnrollmentAccent,
            pnlReportClassCountAccent,
            pnlReportRetentionAccent,
            pnlReportChartCard,
            pnlChartLegendRevenue,
            pnlChartLegendTarget,
            pnlReportHighlightCard,
            pnlReportHighlightTrack,
            pnlReportHighlightFill,
            pnlReportDistributionCard,
            pnlReportDetailCard
        })
        {
            panel.AutoScroll = false;
        }

        pnlReportHighlightCard.AutoScroll = false;
        pnlReportDistributionCard.AutoScroll = false;

        flpAdminReportHeaderActions.FlowDirection = FlowDirection.LeftToRight;
        flpAdminReportHeaderActions.WrapContents = true;
        flpAdminReportHeaderActions.Padding = new Padding(0, 8, 0, 0);
        btnPrintReport.Width = FormHostHelpers.ScaleForDpi(this, 132);
        btnRefreshData.Width = FormHostHelpers.ScaleForDpi(this, 152);
        btnExportReportCsv.Width = FormHostHelpers.ScaleForDpi(this, 132);
        btnPrintReport.Height = FormHostHelpers.ScaleForDpi(this, 40);
        btnRefreshData.Height = FormHostHelpers.ScaleForDpi(this, 40);
        btnExportReportCsv.Height = FormHostHelpers.ScaleForDpi(this, 40);
        btnPrintReport.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 8, 8));
        btnRefreshData.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 8, 8));
        btnExportReportCsv.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 0, 8));

        LayoutHighlightCard();
        LayoutDistributionCard();
        LayoutReportTitleBlock();
        LayoutChartHeader();
        LayoutDetailHeader();
        ApplyResponsiveLayout();
        UpdateReportScrollHeight();
    }

    private void ApplyResponsiveLayout()
    {
        var compact = ClientSize.Width < 1380;
        var narrow = ClientSize.Width < 1240;
        var veryNarrow = ClientSize.Width < 1100;

        tblAdminReportRoot.RowStyles[0].Height = FormHostHelpers.ScaleForDpi(this, veryNarrow ? 170 : compact ? 148 : 118);
        tblAdminReportRoot.RowStyles[1].Height = FormHostHelpers.ScaleForDpi(this, veryNarrow ? 180 : 140);
        tblAdminReportRoot.RowStyles[2].Height = FormHostHelpers.ScaleForDpi(this, compact ? 280 : 170);
        tblAdminReportRoot.RowStyles[3].Height = FormHostHelpers.ScaleForDpi(this, narrow ? 700 : 460);
        tblAdminReportRoot.RowStyles[4].Height = FormHostHelpers.ScaleForDpi(this, 330);

        ConfigureHeaderLayout(compact);
        ConfigureFilterLayout(narrow);
        ConfigureKpiLayout(compact);
        ConfigureMiddleLayout(narrow);

        var filterCompact = ClientSize.Width < 1280;
        btnViewReport.Text = filterCompact ? "XEM" : "XEM BÁO CÁO";
        btnViewReport.MinimumSize = new Size(filterCompact ? 120 : 170, 0);
        lblReportChartTitle.Font = new Font("Segoe UI", compact ? 14F : 16F, FontStyle.Bold);

        LayoutKpiCards();
        LayoutReportTitleBlock();
        LayoutChartHeader();
        LayoutDetailHeader();

        LayoutHighlightCard();
        LayoutDistributionCard();
        UpdateReportScrollHeight();
    }

    private void UpdateReportScrollHeight()
    {
        if (tblAdminReportRoot.IsDisposed)
        {
            return;
        }

        var contentHeight = tblAdminReportRoot.RowStyles
            .Cast<RowStyle>()
            .Sum(row => row.SizeType == SizeType.Absolute ? (int)Math.Ceiling(row.Height) : 0);
        contentHeight += FormHostHelpers.ScaleForDpi(this, 36);

        tblAdminReportRoot.Width = Math.Max(0, ClientSize.Width - Padding.Horizontal - SystemInformation.VerticalScrollBarWidth);
        tblAdminReportRoot.Height = Math.Max(contentHeight, ClientSize.Height - Padding.Vertical);
        AutoScrollMinSize = new Size(0, tblAdminReportRoot.Height + Padding.Vertical + FormHostHelpers.ScaleForDpi(this, 12));
        AutoScroll = true;
    }

    private void LayoutReportTitleBlock()
    {
        var availableWidth = Math.Max(260, pnlAdminReportTitleBlock.ClientSize.Width - 4);
        var compact = availableWidth < 640;

        lblAdminReportTitle.Font = new Font("Segoe UI", compact ? 24F : 28F, FontStyle.Bold);
        lblAdminReportTitle.AutoSize = true;
        lblAdminReportTitle.MaximumSize = new Size(availableWidth, 0);
        lblAdminReportTitle.Location = new Point(0, 0);

        flpAdminReportMeta.AutoSize = true;
        flpAdminReportMeta.WrapContents = compact;
        flpAdminReportMeta.MaximumSize = new Size(availableWidth, 0);
        flpAdminReportMeta.Location = new Point(2, lblAdminReportTitle.Bottom + 2);

        var desiredHeaderHeight = Math.Max(110F, flpAdminReportMeta.Bottom + 24F);
        if (tblAdminReportRoot.RowStyles.Count > 0)
        {
            tblAdminReportRoot.RowStyles[0].Height = Math.Max(tblAdminReportRoot.RowStyles[0].Height, desiredHeaderHeight);
        }
    }

    private void ConfigureHeaderLayout(bool compact)
    {
        tblAdminReportHeaderLayout.SuspendLayout();
        tblAdminReportHeaderLayout.ColumnStyles.Clear();
        tblAdminReportHeaderLayout.RowStyles.Clear();

        if (compact)
        {
            tblAdminReportHeaderLayout.ColumnCount = 1;
            tblAdminReportHeaderLayout.RowCount = 2;
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportHeaderLayout.SetColumn(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetRow(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetColumn(flpAdminReportHeaderActions, 0);
            tblAdminReportHeaderLayout.SetRow(flpAdminReportHeaderActions, 1);

            flpAdminReportHeaderActions.FlowDirection = FlowDirection.LeftToRight;
            flpAdminReportHeaderActions.WrapContents = true;
            flpAdminReportHeaderActions.Dock = DockStyle.Fill;
            btnPrintReport.Width = 160;
            btnRefreshData.Width = 190;
            btnExportReportCsv.Width = 160;
        }
        else
        {
            tblAdminReportHeaderLayout.ColumnCount = 2;
            tblAdminReportHeaderLayout.RowCount = 1;
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 470F));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblAdminReportHeaderLayout.SetColumn(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetRow(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetColumn(flpAdminReportHeaderActions, 1);
            tblAdminReportHeaderLayout.SetRow(flpAdminReportHeaderActions, 0);

            flpAdminReportHeaderActions.FlowDirection = FlowDirection.LeftToRight;
            flpAdminReportHeaderActions.WrapContents = false;
            flpAdminReportHeaderActions.Dock = DockStyle.Fill;
            btnPrintReport.Width = 132;
            btnRefreshData.Width = 152;
            btnExportReportCsv.Width = 132;
        }

        tblAdminReportHeaderLayout.ResumeLayout(true);
    }

    private void ConfigureFilterLayout(bool narrow)
    {
        tblAdminReportFilter.SuspendLayout();
        tblAdminReportFilter.ColumnStyles.Clear();
        tblAdminReportFilter.RowStyles.Clear();

        if (narrow)
        {
            tblAdminReportFilter.ColumnCount = 2;
            tblAdminReportFilter.RowCount = 4;
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tblAdminReportFilter.SetColumn(lblReportType, 0);
            tblAdminReportFilter.SetRow(lblReportType, 0);
            tblAdminReportFilter.SetColumn(lblReportFromDate, 1);
            tblAdminReportFilter.SetRow(lblReportFromDate, 0);
            tblAdminReportFilter.SetColumn(cboReportType, 0);
            tblAdminReportFilter.SetRow(cboReportType, 1);
            tblAdminReportFilter.SetColumn(dtpReportFromDate, 1);
            tblAdminReportFilter.SetRow(dtpReportFromDate, 1);

            tblAdminReportFilter.SetColumn(lblReportToDate, 0);
            tblAdminReportFilter.SetRow(lblReportToDate, 2);
            tblAdminReportFilter.SetColumnSpan(lblReportToDate, 2);
            tblAdminReportFilter.SetColumn(dtpReportToDate, 0);
            tblAdminReportFilter.SetRow(dtpReportToDate, 3);
            tblAdminReportFilter.SetColumn(btnViewReport, 1);
            tblAdminReportFilter.SetRow(btnViewReport, 3);
            btnViewReport.Dock = DockStyle.Fill;
        }
        else
        {
            tblAdminReportFilter.ColumnCount = 4;
            tblAdminReportFilter.RowCount = 2;
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tblAdminReportFilter.SetColumn(lblReportType, 0);
            tblAdminReportFilter.SetRow(lblReportType, 0);
            tblAdminReportFilter.SetColumn(lblReportFromDate, 1);
            tblAdminReportFilter.SetRow(lblReportFromDate, 0);
            tblAdminReportFilter.SetColumn(lblReportToDate, 2);
            tblAdminReportFilter.SetRow(lblReportToDate, 0);
            tblAdminReportFilter.SetColumn(cboReportType, 0);
            tblAdminReportFilter.SetRow(cboReportType, 1);
            tblAdminReportFilter.SetColumn(dtpReportFromDate, 1);
            tblAdminReportFilter.SetRow(dtpReportFromDate, 1);
            tblAdminReportFilter.SetColumn(dtpReportToDate, 2);
            tblAdminReportFilter.SetRow(dtpReportToDate, 1);
            tblAdminReportFilter.SetColumn(btnViewReport, 3);
            tblAdminReportFilter.SetRow(btnViewReport, 1);
            btnViewReport.Dock = DockStyle.Fill;
        }

        tblAdminReportFilter.ResumeLayout(true);
    }

    private void ConfigureKpiLayout(bool compact)
    {
        tblReportKpi.SuspendLayout();
        tblReportKpi.Controls.Clear();
        tblReportKpi.ColumnStyles.Clear();
        tblReportKpi.RowStyles.Clear();

        if (compact)
        {
            tblReportKpi.ColumnCount = 2;
            tblReportKpi.RowCount = 2;
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            AddKpiCard(pnlReportRevenue, 0, 0, new Padding(0, 0, 12, 12));
            AddKpiCard(pnlReportEnrollment, 1, 0, new Padding(0, 0, 0, 12));
            AddKpiCard(pnlReportClassCount, 0, 1, new Padding(0, 0, 12, 0));
            AddKpiCard(pnlReportRetention, 1, 1, Padding.Empty);
        }
        else
        {
            tblReportKpi.ColumnCount = 4;
            tblReportKpi.RowCount = 1;
            for (var index = 0; index < 4; index++)
            {
                tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            AddKpiCard(pnlReportRevenue, 0, 0, new Padding(0, 0, 18, 0));
            AddKpiCard(pnlReportEnrollment, 1, 0, new Padding(0, 0, 18, 0));
            AddKpiCard(pnlReportClassCount, 2, 0, new Padding(0, 0, 18, 0));
            AddKpiCard(pnlReportRetention, 3, 0, Padding.Empty);
        }

        tblReportKpi.ResumeLayout(true);
    }

    private void AddKpiCard(Control card, int column, int row, Padding margin)
    {
        card.Dock = DockStyle.Fill;
        card.Margin = margin;
        tblReportKpi.Controls.Add(card, column, row);
    }

    private void ConfigureMiddleLayout(bool narrow)
    {
        tblReportMiddle.SuspendLayout();
        tblReportMiddle.ColumnStyles.Clear();
        tblReportMiddle.RowStyles.Clear();

        if (narrow)
        {
            tblReportMiddle.ColumnCount = 1;
            tblReportMiddle.RowCount = 2;
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            tblReportMiddle.SetColumn(pnlReportChartCard, 0);
            tblReportMiddle.SetRow(pnlReportChartCard, 0);
            tblReportMiddle.SetColumn(tblReportSideColumn, 0);
            tblReportMiddle.SetRow(tblReportSideColumn, 1);
            pnlReportChartCard.Margin = new Padding(0, 0, 0, 16);
            tblReportSideColumn.Margin = Padding.Empty;

            tblReportSideColumn.RowStyles.Clear();
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        }
        else
        {
            tblReportMiddle.ColumnCount = 2;
            tblReportMiddle.RowCount = 1;
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.5F));
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblReportMiddle.SetColumn(pnlReportChartCard, 0);
            tblReportMiddle.SetRow(pnlReportChartCard, 0);
            tblReportMiddle.SetColumn(tblReportSideColumn, 1);
            tblReportMiddle.SetRow(tblReportSideColumn, 0);
            pnlReportChartCard.Margin = new Padding(0, 0, 24, 0);

            tblReportSideColumn.RowStyles.Clear();
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 63F));
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 37F));
        }

        tblReportMiddle.ResumeLayout(true);
    }

    private void LayoutKpiCards()
    {
        LayoutKpiCard(pnlReportRevenue, lblReportRevenueTitle, lblReportRevenueValue, lblReportRevenueTrend, lblReportRevenueIcon);
        LayoutKpiCard(pnlReportEnrollment, lblReportEnrollmentTitle, lblReportEnrollmentValue, lblReportEnrollmentTrend, lblReportEnrollmentIcon);
        LayoutKpiCard(pnlReportClassCount, lblReportClassCountTitle, lblReportClassCountValue, lblReportClassCountTrend, lblReportClassCountIcon);
        LayoutKpiCard(pnlReportRetention, lblReportRetentionTitle, lblReportRetentionValue, lblReportRetentionTrend, lblReportRetentionIcon);
    }

    private static void LayoutKpiCard(Panel panel, Label title, Label value, Label trend, Label icon)
    {
        var left = panel.Padding.Left + 8;
        var top = panel.Padding.Top;
        var contentWidth = Math.Max(150, panel.ClientSize.Width - panel.Padding.Horizontal - 16);

        title.AutoSize = false;
        title.Location = new Point(left, top);
        title.Size = new Size(contentWidth - 46, 26);

        value.AutoSize = false;
        value.Location = new Point(left, title.Bottom + 2);
        value.Size = new Size(contentWidth, 52);

        trend.AutoSize = false;
        trend.Location = new Point(left, value.Bottom + 2);
        trend.Size = new Size(contentWidth, 24);

        icon.Size = new Size(34, 34);
        icon.Location = new Point(Math.Max(left + 10, left + contentWidth - 36), top);
    }

    private void LayoutChartHeader()
    {
        var headerWidth = pnlReportChartHeader.ClientSize.Width;
        if (headerWidth <= 0 || pnlReportChartHeader.IsDisposed)
        {
            return;
        }

        var compact = headerWidth < FormHostHelpers.ScaleForDpi(this, 700);
        flpChartLegend.WrapContents = compact;
        flpChartLegend.Anchor = compact ? AnchorStyles.Top | AnchorStyles.Left : AnchorStyles.Top | AnchorStyles.Right;

        var titleMaxWidth = compact
            ? headerWidth
            : Math.Max(FormHostHelpers.ScaleForDpi(this, 220), headerWidth - flpChartLegend.Width - FormHostHelpers.ScaleForDpi(this, 20));
        lblReportChartTitle.MaximumSize = new Size(titleMaxWidth, 0);

        flpChartLegend.Location = compact
            ? new Point(0, lblReportChartTitle.Bottom + FormHostHelpers.ScaleForDpi(this, 6))
            : new Point(Math.Max(0, headerWidth - flpChartLegend.Width), FormHostHelpers.ScaleForDpi(this, 12));

        pnlReportChartHeader.Height = compact
            ? Math.Max(FormHostHelpers.ScaleForDpi(this, 70), flpChartLegend.Bottom + FormHostHelpers.ScaleForDpi(this, 8))
            : FormHostHelpers.ScaleForDpi(this, 54);
    }

    private void LayoutDetailHeader()
    {
        var right = pnlReportDetailHeader.ClientSize.Width - 24;
        flpReportDetailNavigation.Location = new Point(right - flpReportDetailNavigation.Width, 15);
        lblReportDetailPaging.MaximumSize = new Size(280, 0);

        var pagingSize = TextRenderer.MeasureText(
            lblReportDetailPaging.Text,
            lblReportDetailPaging.Font,
            new Size(lblReportDetailPaging.MaximumSize.Width, 0),
            TextFormatFlags.WordBreak);

        var pagingX = Math.Max(24, flpReportDetailNavigation.Left - pagingSize.Width - 10);
        lblReportDetailPaging.Location = new Point(pagingX, 24);
    }

    private void LayoutHighlightCard()
    {
        const int left = 28;
        const int top = 14;

        var contentWidth = Math.Max(160, pnlReportHighlightCard.ClientSize.Width - (left * 2));

        lblReportHighlightIcon.AutoSize = true;
        lblReportHighlightIcon.Location = new Point(left, top);

        lblReportHighlightTitle.AutoSize = true;
        lblReportHighlightTitle.MaximumSize = new Size(contentWidth, 0);
        lblReportHighlightTitle.Location = new Point(left, lblReportHighlightIcon.Bottom + 6);

        lblReportHighlightBody.AutoSize = true;
        lblReportHighlightBody.MaximumSize = new Size(contentWidth, 0);
        lblReportHighlightBody.Location = new Point(left, lblReportHighlightTitle.Bottom + 8);

        pnlReportHighlightTrack.Width = contentWidth;
        pnlReportHighlightTrack.Location = new Point(left, lblReportHighlightBody.Bottom + 10);

        var minHeight = pnlReportHighlightTrack.Bottom + 16;
        if (pnlReportHighlightCard.MinimumSize.Height < minHeight)
        {
            pnlReportHighlightCard.MinimumSize = new Size(0, minHeight);
        }
    }

    private void LayoutDistributionCard()
    {
        const int left = 28;
        const int top = 22;
        const int spacing = 10;

        lblReportDistributionTitle.AutoSize = true;
        lblReportDistributionTitle.Location = new Point(left, top);

        var tableTop = lblReportDistributionTitle.Bottom + spacing;
        var width = Math.Max(180, pnlReportDistributionCard.ClientSize.Width - (left * 2));
        var height = Math.Max(90, pnlReportDistributionCard.ClientSize.Height - tableTop - 18);

        tblReportDistribution.Dock = DockStyle.None;
        tblReportDistribution.Location = new Point(left, tableTop);
        tblReportDistribution.Size = new Size(width, height);
        tblReportDistribution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    }

    private void EnsureDefaultReportLoaded()
    {
        if (_initialReportLoaded)
        {
            return;
        }

        _initialReportLoaded = true;
        LoadDefaultReport();
    }

    private void ApplyLocalizedText()
    {
        Text = "Báo cáo thống kê";
        lblAdminReportTitle.Text = "BÁO CÁO THỐNG KÊ";
        lblAdminReportSession.Text = $"PHIEN: {DateTime.Now:dd/MM/yyyy HH:mm}";
        lblAdminReportStatus.Text = "TRẠNG THÁI: ADMIN";
        btnPrintReport.Text = "IN BÁO CÁO";
        btnRefreshData.Text = "CẬP NHẬT DỮ LIỆU";
        btnViewReport.Text = "XEM BÁO CÁO";
        btnExportReportCsv.Text = "XUẤT FILE CSV";
        lblReportType.Text = "LOẠI BÁO CÁO";
        lblReportFromDate.Text = "TỪ NGÀY";
        lblReportToDate.Text = "ĐẾN NGÀY";
        lblReportChartTitle.Text = "XU HƯỚNG THEO THÁNG";
        lblChartLegendRevenue.Text = "THỰC TẾ";
        lblChartLegendTarget.Text = "MỤC TIÊU";
        lblReportDetailTitle.Text = "CHI TIẾT PHÁT SINH";
        lblReportDetailPaging.Text = "Hiển thị 0 / 0 kết quả";
        btnReportPrevPage.Text = "<";
        btnReportNextPage.Text = ">";
        lblReportDistributionTitle.Text = "PHÂN BỔ THEO KHÓA";
        lblReportHighlightTitle.Text = "Tổng quan";
        lblReportHighlightBody.Text = "Báo cáo tổng hợp theo dữ liệu từ database.";

        lblReportRevenueIcon.Text = "₫";
        lblReportEnrollmentIcon.Text = "👥";
        lblReportClassCountIcon.Text = "🏫";
        lblReportRetentionIcon.Text = "⚠";
        lblReportHighlightIcon.Text = "i";

        cboReportType.Items.Clear();
        cboReportType.Items.AddRange(["Doanh thu tổng hợp", "Tuyển sinh", "Công nợ"]);
        cboReportType.SelectedIndex = 0;
    }

    private void ConfigureVisualStyle()
    {
        BackColor = Color.FromArgb(239, 247, 255);
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1080, 720));

        StyleSurfaceCard(pnlAdminReportFilterCard, Color.FromArgb(223, 243, 255));
        StyleSurfaceCard(pnlReportChartCard, Color.White);
        StyleSurfaceCard(pnlReportDistributionCard, Color.FromArgb(217, 237, 252));
        StyleSurfaceCard(pnlReportDetailCard, Color.FromArgb(222, 242, 255));
        StyleSurfaceCard(pnlReportHighlightCard, Color.FromArgb(127, 229, 227));

        StyleHeaderButton(btnPrintReport, Color.FromArgb(214, 237, 249), Color.FromArgb(10, 36, 66));
        StyleHeaderButton(btnRefreshData, Color.FromArgb(9, 72, 137), Color.White);
        StyleHeaderButton(btnViewReport, Color.FromArgb(112, 227, 223), Color.FromArgb(11, 91, 98));
        StyleHeaderButton(btnExportReportCsv, Color.White, Color.FromArgb(9, 60, 123), Color.FromArgb(182, 204, 228));
        StyleMiniNavButton(btnReportPrevPage);
        StyleMiniNavButton(btnReportNextPage);

        StyleKpiCard(pnlReportRevenue, pnlReportRevenueAccent, Color.FromArgb(10, 73, 146));
        StyleKpiCard(pnlReportEnrollment, pnlReportEnrollmentAccent, Color.FromArgb(22, 126, 120));
        StyleKpiCard(pnlReportClassCount, pnlReportClassCountAccent, Color.FromArgb(115, 126, 141));
        StyleKpiCard(pnlReportRetention, pnlReportRetentionAccent, Color.FromArgb(115, 49, 4));

        pnlReportHighlightTrack.BackColor = Color.FromArgb(154, 238, 236);
        pnlReportHighlightFill.BackColor = Color.FromArgb(16, 117, 121);
        pnlChartLegendRevenue.BackColor = Color.FromArgb(20, 83, 144);
        pnlChartLegendTarget.BackColor = Color.FromArgb(22, 126, 120);

        lblAdminReportTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminReportSession.ForeColor = Color.FromArgb(50, 61, 76);
        lblAdminReportStatus.ForeColor = Color.FromArgb(22, 90, 88);
        lblReportHighlightTitle.ForeColor = Color.FromArgb(7, 87, 96);
        lblReportHighlightBody.ForeColor = Color.FromArgb(24, 93, 99);

        StyleCombo(cboReportType);
        StyleDatePicker(dtpReportFromDate);
        StyleDatePicker(dtpReportToDate);

        dgvAdminReportDetail.BorderStyle = BorderStyle.None;
        dgvAdminReportDetail.AutoGenerateColumns = true;
        dgvAdminReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAdminReportDetail.RowTemplate.Height = FormHostHelpers.ScaleForDpi(this, 40);
        dgvAdminReportDetail.ColumnHeadersHeight = FormHostHelpers.ScaleForDpi(this, 42);
        AppTheme.StyleGrid(dgvAdminReportDetail);
    }

    private void ConfigureChartSurface()
    {
        var area = chtAdminRevenue.ChartAreas["DefaultArea"];
        area.BackColor = Color.White;
        area.AxisX.MajorGrid.Enabled = false;
        area.AxisY.MajorGrid.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
        area.AxisX.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisY.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 91, 110);
        area.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 91, 110);
        area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        area.AxisX.MajorTickMark.Enabled = false;
        area.AxisY.MajorTickMark.Enabled = false;
        area.AxisX.Interval = 1;
        area.AxisY.IsStartedFromZero = true;

        var legend = chtAdminRevenue.Legends["DefaultLegend"];
        legend.Enabled = false;
    }

    private void BindReportEvents()
    {
        btnViewReport.Click += (_, _) => ApplyReportView();
        btnRefreshData.Click += (_, _) => RefreshReportData();
        btnExportReportCsv.Click += (_, _) => ExportCurrentReportCsv();
        btnPrintReport.Click += (_, _) => ShowFeatureHint("In bao cao");
        cboReportType.SelectedIndexChanged += (_, _) => ApplyReportView();
        btnReportPrevPage.Click += (_, _) => ShowFeatureHint("Dieu huong trang");
        btnReportNextPage.Click += (_, _) => ShowFeatureHint("Dieu huong trang");
    }

    private void LoadDefaultReport()
    {
        var today = DateTime.Today;
        dtpReportFromDate.Value = new DateTime(today.Year, 1, 1);
        dtpReportToDate.Value = today;
        ApplyReportView();
    }

    private void ApplyReportView()
    {
        if (dtpReportFromDate.Value.Date > dtpReportToDate.Value.Date)
        {
            MessageBox.Show(this, "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var selectedType = GetSelectedReportType();
            _currentScenario = BuildScenario(selectedType, dtpReportFromDate.Value.Date, dtpReportToDate.Value.Date);
            BindScenarioToUi(_currentScenario);
            ApplyReportTypeIcons(selectedType);
            lblAdminReportSession.Text = $"PHIEN: {DateTime.Now:dd/MM/yyyy HH:mm}";
        lblAdminReportStatus.Text = "TRẠNG THÁI: ADMIN";
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAdminReports));
            MessageBox.Show(this, "Không tải được dữ liệu báo cáo. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BindScenarioToUi(ReportScenario scenario)
    {
        lblReportRevenueTitle.Text = scenario.RevenueTitle;
        lblReportRevenueValue.Text = scenario.RevenueValue;
        lblReportRevenueTrend.Text = scenario.RevenueTrend;

        lblReportEnrollmentTitle.Text = scenario.EnrollmentTitle;
        lblReportEnrollmentValue.Text = scenario.EnrollmentValue;
        lblReportEnrollmentTrend.Text = scenario.EnrollmentTrend;

        lblReportClassCountTitle.Text = scenario.ClassTitle;
        lblReportClassCountValue.Text = scenario.ClassValue;
        lblReportClassCountTrend.Text = scenario.ClassTrend;

        lblReportRetentionTitle.Text = scenario.RetentionTitle;
        lblReportRetentionValue.Text = scenario.RetentionValue;
        lblReportRetentionTrend.Text = scenario.RetentionTrend;
        lblReportChartTitle.Text = scenario.ChartTitle;
        lblReportDetailTitle.Text = scenario.DetailTitle;
        lblReportHighlightTitle.Text = scenario.HighlightTitle;
        lblReportHighlightBody.Text = scenario.HighlightBody;
        lblReportDetailPaging.Text = scenario.DetailPaging;

        lblDistributionCourse1Name.Text = scenario.Distributions[0].Name;
        lblDistributionCourse1Value.Text = scenario.Distributions[0].Value;
        lblDistributionCourse2Name.Text = scenario.Distributions[1].Name;
        lblDistributionCourse2Value.Text = scenario.Distributions[1].Value;
        lblDistributionCourse3Name.Text = scenario.Distributions[2].Name;
        lblDistributionCourse3Value.Text = scenario.Distributions[2].Value;

        dgvAdminReportDetail.DataSource = scenario.DetailTable;
        FormatReportGrid();
        BindSeries(scenario.ChartPoints, scenario.TargetPoints);
        UpdateHighlightProgressWidth(scenario.HighlightProgress);
        LayoutHighlightCard();
        LayoutDistributionCard();
        LayoutChartHeader();
        LayoutDetailHeader();
    }

    private void ApplyReportTypeIcons(string reportType)
    {
        switch (reportType)
        {
            case "Tuyen sinh":
                lblReportRevenueIcon.Text = "📝";
                lblReportEnrollmentIcon.Text = "👥";
                lblReportClassCountIcon.Text = "🏫";
                lblReportRetentionIcon.Text = "🎯";
                break;
            case "Cong no":
                lblReportRevenueIcon.Text = "💸";
                lblReportEnrollmentIcon.Text = "🧾";
                lblReportClassCountIcon.Text = "🏫";
                lblReportRetentionIcon.Text = "⚠";
                break;
            default:
                lblReportRevenueIcon.Text = "₫";
                lblReportEnrollmentIcon.Text = "👥";
                lblReportClassCountIcon.Text = "🏫";
                lblReportRetentionIcon.Text = "📊";
                break;
        }
    }

    private ReportScenario BuildScenario(string reportType, DateTime fromDate, DateTime toDate)
    {
        var stats = _dataService.GetAdminDashboardStats();
        var detailTable = _dataService.GetReportDetail(reportType, fromDate, toDate);
        var chartPoints = BuildChartPoints(reportType, fromDate, toDate, detailTable);
        var targetPoints = BuildTargetPoints(chartPoints, reportType);
        var distributions = BuildDistributions(reportType, fromDate, toDate, detailTable);
        var detailCount = detailTable.Rows.Count;

        return reportType switch
        {
            "Tuyen sinh" => new ReportScenario
            {
                RevenueTitle = "Tong ho so ghi danh",
                RevenueValue = detailCount.ToString("N0", ReportCulture),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "Học viên mới trong kỳ",
                EnrollmentValue = CountDistinctValues(detailTable, "Hoc vien").ToString("N0", ReportCulture),
                EnrollmentTrend = $"Thang nay: {stats.NewStudentsThisMonth:N0}",
                ClassTitle = "Số lớp đang mở",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tổng học viên: {stats.TotalStudents:N0}",
                RetentionTitle = "Tổng học viên trung tâm",
                RetentionValue = stats.TotalStudents.ToString("N0", ReportCulture),
                RetentionTrend = $"Tong GV: {stats.TotalTeachers:N0}",
                ChartTitle = "XU HUONG GHI DANH THEO THANG",
                DetailTitle = "CHI TIET GHI DANH TRONG KY",
                HighlightTitle = "Tuyen sinh dang tang",
                HighlightBody = $"Co {detailCount:N0} ho so trong khoang {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}.",
                HighlightProgress = BuildProgressValue(detailCount, Math.Max(1, stats.TotalStudents)),
                DetailPaging = BuildPagingText(detailCount),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            },
            "Cong no" => new ReportScenario
            {
                RevenueTitle = "Tong cong no",
                RevenueValue = FormatCompactMoney(stats.TotalDebt),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "So bien lai",
                EnrollmentValue = stats.TotalReceipts.ToString("N0", ReportCulture),
                EnrollmentTrend = $"Doanh thu: {FormatCompactMoney(stats.TotalRevenue)}",
                ClassTitle = "Lớp đang mở",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tong staff: {stats.TotalStaff:N0}",
                RetentionTitle = "Học viên còn nợ",
                RetentionValue = detailTable.Rows.Count.ToString("N0", ReportCulture),
                RetentionTrend = "Theo doi cong no chua thanh toan",
                ChartTitle = "XU HUONG CONG NO THEO THANG",
                DetailTitle = "CHI TIET CONG NO TRONG KY",
                HighlightTitle = "Cong no can theo doi",
                HighlightBody = $"Tong cong no hien tai la {FormatMoney(stats.TotalDebt)}.",
                HighlightProgress = BuildProgressValue(stats.TotalDebt, Math.Max(1M, stats.TotalRevenue + stats.TotalDebt)),
                DetailPaging = BuildPagingText(detailTable.Rows.Count),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            },
            _ => new ReportScenario
            {
                RevenueTitle = "Tổng doanh thu đã thu",
                RevenueValue = FormatCompactMoney(stats.TotalRevenue),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "Học viên mới",
                EnrollmentValue = stats.NewStudentsThisMonth.ToString("N0", ReportCulture),
                EnrollmentTrend = $"Tổng học viên: {stats.TotalStudents:N0}",
                ClassTitle = "Số lớp đang mở",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tong GV: {stats.TotalTeachers:N0}",
                RetentionTitle = "Tong cong no",
                RetentionValue = FormatCompactMoney(stats.TotalDebt),
                RetentionTrend = $"Tong bien lai: {stats.TotalReceipts:N0}",
                ChartTitle = "XU HUONG DOANH THU THEO THANG",
                DetailTitle = "CHI TIET THU HOC PHI TRONG KY",
                HighlightTitle = "Doanh thu đã ghi nhận",
                HighlightBody = $"Da thu {FormatMoney(stats.TotalRevenue)} va con no {FormatMoney(stats.TotalDebt)}.",
                HighlightProgress = BuildProgressValue(stats.TotalRevenue, Math.Max(1M, stats.TotalRevenue + stats.TotalDebt)),
                DetailPaging = BuildPagingText(detailTable.Rows.Count),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            }
        };
    }

    private IReadOnlyList<ReportPoint> BuildChartPoints(string reportType, DateTime fromDate, DateTime toDate, DataTable detailTable)
    {
        IReadOnlyList<ReportPoint> points = reportType switch
        {
            "Tuyen sinh" => _dataService.GetMonthlyEnrollmentCounts(fromDate, toDate),
            "Cong no" => BuildMonthlySeriesFromTable(detailTable, "Ngay doi soat", "Con no"),
            _ => _dataService.GetMonthlyRevenue(fromDate, toDate)
        };

        return EnsureSeriesHasPoints(points, fromDate, toDate);
    }

    private IReadOnlyList<ReportPoint> BuildTargetPoints(IReadOnlyList<ReportPoint> sourcePoints, string reportType)
    {
        var multiplier = reportType == "Cong no" ? 0.85M : 0.90M;

        return sourcePoints
            .Select(point => new ReportPoint
            {
                Label = point.Label,
                Value = Math.Round(point.Value * multiplier, 0)
            })
            .ToList();
    }

    private (string Name, string Value)[] BuildDistributions(string reportType, DateTime fromDate, DateTime toDate, DataTable detailTable)
    {
        IEnumerable<IGrouping<string, DataRow>> groupedRows = reportType switch
        {
            "Tuyen sinh" => detailTable.AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty),
            "Cong no" => _dataService.GetDebtList(null, null, fromDate, toDate)
                .AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty),
            _ => _dataService.GetClassList()
                .AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty)
        };

        var summary = groupedRows
            .Select(group => new
            {
                Name = group.Key,
                Count = group.Count()
            })
            .Where(item => !string.IsNullOrWhiteSpace(item.Name))
            .OrderByDescending(item => item.Count)
            .ToList();

        var total = Math.Max(1, summary.Sum(item => item.Count));
        var result = summary
            .Take(3)
            .Select(item => (item.Name, $"{Math.Round(item.Count * 100M / total, 1):0.#}%"))
            .ToList();

        while (result.Count < 3)
        {
            result.Add(("-", "0%"));
        }

        return [result[0], result[1], result[2]];
    }

    private IReadOnlyList<ReportPoint> BuildMonthlySeriesFromTable(DataTable sourceTable, string dateColumn, string valueColumn)
    {
        return sourceTable.AsEnumerable()
            .Select(row => new
            {
                Date = TryParseDate(row[dateColumn]?.ToString()),
                Value = TryParseMoney(row[valueColumn]?.ToString())
            })
            .Where(item => item.Date.HasValue)
            .GroupBy(item => new { item.Date!.Value.Year, item.Date.Value.Month })
            .OrderBy(group => group.Key.Year)
            .ThenBy(group => group.Key.Month)
            .Select(group => new ReportPoint
            {
                Label = $"{group.Key.Month:00}/{group.Key.Year}",
                Value = group.Sum(item => item.Value)
            })
            .ToList();
    }

    private IReadOnlyList<ReportPoint> EnsureSeriesHasPoints(IReadOnlyList<ReportPoint> points, DateTime fromDate, DateTime toDate)
    {
        if (points.Count > 0)
        {
            return points;
        }

        var firstMonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        var lastMonth = new DateTime(toDate.Year, toDate.Month, 1);
        var monthCount = Math.Max(1, ((lastMonth.Year - firstMonth.Year) * 12) + lastMonth.Month - firstMonth.Month + 1);

        return Enumerable.Range(0, monthCount)
            .Select(offset => firstMonth.AddMonths(offset))
            .Select(date => new ReportPoint
            {
                Label = $"{date.Month:00}/{date.Year}",
                Value = 0
            })
            .ToList();
    }

    private void BindSeries(IReadOnlyList<ReportPoint> actualPoints, IReadOnlyList<ReportPoint> targetPoints)
    {
        chtAdminRevenue.Series.Clear();

        var actualSeries = new Series("Thuc te")
        {
            ChartType = SeriesChartType.Column,
            Color = Color.FromArgb(20, 83, 144),
            BorderWidth = 0,
            IsValueShownAsLabel = false,
            IsXValueIndexed = true
        };
        actualSeries["PointWidth"] = "0.58";

        foreach (var point in actualPoints)
        {
            actualSeries.Points.AddXY(point.Label, (double)point.Value);
        }

        var targetSeries = new Series("Muc tieu")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.FromArgb(22, 126, 120),
            BorderWidth = 3,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 7,
            IsXValueIndexed = true
        };

        foreach (var point in targetPoints)
        {
            targetSeries.Points.AddXY(point.Label, (double)point.Value);
        }

        chtAdminRevenue.Series.Add(actualSeries);
        chtAdminRevenue.Series.Add(targetSeries);
    }

    private void FormatReportGrid()
    {
        foreach (DataGridViewColumn column in dgvAdminReportDetail.Columns)
        {
            var header = column.HeaderText.ToLowerInvariant();
            var isMoneyColumn = header.Contains("thu") || header.Contains("phi") || header.Contains("tien") || header.Contains("no");
            column.DefaultCellStyle.Alignment = isMoneyColumn
                ? DataGridViewContentAlignment.MiddleRight
                : DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private void UpdateHighlightProgressWidth(double progress)
    {
        var width = Math.Max(24, (int)(pnlReportHighlightTrack.ClientSize.Width * Math.Clamp(progress, 0.08, 1.0)));
        pnlReportHighlightFill.Width = width;
    }

    private void RefreshReportData()
    {
        ApplyReportView();
        MessageBox.Show(this, "Đã cập nhật lại dữ liệu báo cáo từ database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ExportCurrentReportCsv()
    {
        if (_currentScenario is null)
        {
            return;
        }

        try
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"bao-cao-{GetSelectedReportType().ToLowerInvariant().Replace(' ', '-')}-{DateTime.Now:yyyyMMdd-HHmmss}.csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var csv = BuildCsv(_currentScenario.DetailTable);
            File.WriteAllText(dialog.FileName, csv, new UTF8Encoding(true));
            MessageBox.Show(this, "Đã xuất file CSV thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAdminReports));
            MessageBox.Show(this, "Không xuất được file CSV. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ShowFeatureHint(string actionName)
    {
        MessageBox.Show(
            this,
            $"{actionName} đang được giữ ở mức cơ bản để dễ demo. Dữ liệu hiện tại đã lấy từ SQL Server/EF.",
            "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private string GetSelectedReportType()
    {
        return cboReportType.SelectedIndex switch
        {
            1 => "Tuyen sinh",
            2 => "Cong no",
            _ => "Doanh thu tong hop"
        };
    }

    private string GetReadableReportType()
    {
        return cboReportType.SelectedItem?.ToString() ?? "Bao cao";
    }

    private static int CountDistinctValues(DataTable table, string columnName)
    {
        if (!table.Columns.Contains(columnName))
        {
            return 0;
        }

        return table.AsEnumerable()
            .Select(row => row[columnName]?.ToString())
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count();
    }

    private static string BuildPagingText(int totalRows)
    {
        return $"Hien thi {Math.Min(10, totalRows)} / {totalRows} ket qua";
    }

    private static string BuildTrendText(IReadOnlyList<ReportPoint> points)
    {
        if (points.Count < 2)
        {
            return "Không đổi";
        }

        var previous = points[^2].Value;
        var current = points[^1].Value;
        if (previous == 0)
        {
            return current == 0 ? "Không đổi" : "Tăng mới";
        }

        var change = Math.Round((current - previous) * 100M / previous, 1);
        return change switch
        {
            > 0 => $"Tang {change:0.#}%",
            < 0 => $"Giam {Math.Abs(change):0.#}%",
            _ => "Không đổi"
        };
    }

    private static double BuildProgressValue(decimal value, decimal total)
    {
        if (total <= 0)
        {
            return 0.08;
        }

        return Math.Clamp((double)(value / total), 0.08, 1.0);
    }

    private static string FormatCompactMoney(decimal amount)
    {
        if (amount >= 1_000_000_000M)
        {
            return $"{amount / 1_000_000_000M:0.##} ty";
        }

        if (amount >= 1_000_000M)
        {
            return $"{amount / 1_000_000M:0.##} tr";
        }

        if (amount >= 1_000M)
        {
            return $"{amount / 1_000M:0.##} nghin";
        }

        return amount.ToString("N0", ReportCulture);
    }

    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("N0", ReportCulture) + " VND";
    }

    private static DateTime? TryParseDate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return DateTime.TryParseExact(value, "dd/MM/yyyy", ReportCulture, DateTimeStyles.None, out var parsedDate)
            ? parsedDate
            : null;
    }

    private static decimal TryParseMoney(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0;
        }

        var sanitized = value
            .Replace("VND", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(".", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(",", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Trim();

        return decimal.TryParse(sanitized, NumberStyles.Number, CultureInfo.InvariantCulture, out var parsedValue)
            ? parsedValue
            : 0;
    }

    private static string BuildCsv(DataTable table)
    {
        var builder = new StringBuilder();
        var headers = table.Columns.Cast<DataColumn>().Select(column => EscapeCsv(column.ColumnName));
        builder.AppendLine(string.Join(",", headers));

        foreach (DataRow row in table.Rows)
        {
            var cells = row.ItemArray.Select(cell => EscapeCsv(cell?.ToString() ?? string.Empty));
            builder.AppendLine(string.Join(",", cells));
        }

        return builder.ToString();
    }

    private static string EscapeCsv(string value)
    {
        var escaped = value.Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }

    private static void StyleSurfaceCard(Panel panel, Color backColor)
    {
        panel.BackColor = backColor;
        panel.BorderStyle = BorderStyle.FixedSingle;
    }

    private static void StyleHeaderButton(Button button, Color backColor, Color foreColor, Color? borderColor = null)
    {
        button.BackColor = backColor;
        button.ForeColor = foreColor;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = borderColor ?? backColor;
        button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
    }

    private static void StyleMiniNavButton(Button button)
    {
        button.BackColor = Color.FromArgb(234, 244, 252);
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = Color.FromArgb(198, 216, 233);
        button.ForeColor = Color.FromArgb(49, 58, 71);
        button.Cursor = Cursors.Hand;
    }

    private static void StyleCombo(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Color.White;
        comboBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
    }

    private static void StyleDatePicker(DateTimePicker picker)
    {
        picker.CalendarMonthBackground = Color.White;
        picker.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
    }

    private static void StyleKpiCard(Panel panel, Panel accent, Color accentColor)
    {
        panel.BackColor = Color.White;
        panel.BorderStyle = BorderStyle.FixedSingle;
        accent.BackColor = accentColor;
    }

    private sealed class ReportScenario
    {
        public required string RevenueTitle { get; init; }
        public required string RevenueValue { get; init; }
        public required string RevenueTrend { get; init; }
        public required string EnrollmentTitle { get; init; }
        public required string EnrollmentValue { get; init; }
        public required string EnrollmentTrend { get; init; }
        public required string ClassTitle { get; init; }
        public required string ClassValue { get; init; }
        public required string ClassTrend { get; init; }
        public required string RetentionTitle { get; init; }
        public required string RetentionValue { get; init; }
        public required string RetentionTrend { get; init; }
        public required string ChartTitle { get; init; }
        public required string DetailTitle { get; init; }
        public required string HighlightTitle { get; init; }
        public required string HighlightBody { get; init; }
        public required double HighlightProgress { get; init; }
        public required string DetailPaging { get; init; }
        public required (string Name, string Value)[] Distributions { get; init; }
        public required IReadOnlyList<ReportPoint> ChartPoints { get; init; }
        public required IReadOnlyList<ReportPoint> TargetPoints { get; init; }
        public required DataTable DetailTable { get; init; }
    }
}
