using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class UiHelpers
{
    public static Panel CreatePanel(string name, DockStyle dock = DockStyle.None)
    {
        return new Panel
        {
            Name = name,
            Dock = dock,
            BackColor = AppTheme.Surface
        };
    }

    public static Label CreateLabel(string name, string text, Font? font = null, Color? foreColor = null)
    {
        return new Label
        {
            Name = name,
            Text = text,
            Font = font ?? AppTheme.FontBody,
            ForeColor = foreColor ?? AppTheme.TextPrimary,
            AutoSize = true,
            Margin = new Padding(0, 0, 0, 8)
        };
    }

    public static TextBox CreateTextBox(string name, string placeholder = "")
    {
        return new TextBox
        {
            Name = name,
            PlaceholderText = placeholder,
            Margin = new Padding(0, 0, 0, 10),
            Width = 220
        };
    }

    public static ComboBox CreateComboBox(string name, params string[] items)
    {
        var combo = new ComboBox
        {
            Name = name,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(0, 0, 0, 10),
            Width = 220
        };
        if (items.Length > 0)
        {
            combo.Items.AddRange(items);
            combo.SelectedIndex = 0;
        }

        return combo;
    }

    public static DateTimePicker CreateDateTimePicker(string name)
    {
        return new DateTimePicker
        {
            Name = name,
            Format = DateTimePickerFormat.Short,
            Width = 220,
            Margin = new Padding(0, 0, 0, 10)
        };
    }

    public static Button CreateButton(string name, string text, string style = "primary")
    {
        var button = new Button
        {
            Name = name,
            Text = text,
            Width = 120,
            Margin = new Padding(0, 0, 10, 0)
        };

        switch (style)
        {
            case "secondary":
                AppTheme.StyleSecondaryButton(button);
                break;
            case "danger":
                AppTheme.StyleDangerButton(button);
                break;
            default:
                AppTheme.StylePrimaryButton(button);
                break;
        }

        return button;
    }

    public static FlowLayoutPanel CreateButtonBar(string name)
    {
        return new FlowLayoutPanel
        {
            Name = name,
            AutoSize = true,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Color.Transparent
        };
    }

    public static DataGridView CreateGrid(string name, DataTable data)
    {
        var grid = new DataGridView
        {
            Name = name,
            Dock = DockStyle.Fill,
            DataSource = data,
            ReadOnly = false
        };
        AppTheme.StyleGrid(grid);
        return grid;
    }

    public static GroupBox CreateGroupBox(string name, string text)
    {
        var group = new GroupBox
        {
            Name = name,
            Text = text,
            Dock = DockStyle.Fill
        };
        AppTheme.StyleGroupBox(group);
        return group;
    }

    public static TableLayoutPanel CreateFieldGrid(string name, int rows, int columns)
    {
        var panel = new TableLayoutPanel
        {
            Name = name,
            Dock = DockStyle.Fill,
            AutoScroll = false,
            ColumnCount = columns,
            RowCount = rows,
            BackColor = Color.Transparent,
            Padding = new Padding(0)
        };
        for (var i = 0; i < columns; i++)
        {
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
        }

        for (var i = 0; i < rows; i++)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        return panel;
    }

    public static Panel CreateLabeledField(string labelName, string labelText, Control input)
    {
        var panel = new Panel
        {
            AutoSize = true,
            Dock = DockStyle.Top,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 10, 8)
        };
        var stack = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoSize = true,
            BackColor = Color.Transparent
        };
        stack.Controls.Add(CreateLabel(labelName, labelText));
        stack.Controls.Add(input);
        panel.Controls.Add(stack);
        return panel;
    }

    public static TableLayoutPanel CreateContentGrid(string name, params float[] percents)
    {
        var panel = new TableLayoutPanel
        {
            Name = name,
            Dock = DockStyle.Fill,
            RowCount = 1,
            ColumnCount = percents.Length,
            BackColor = Color.Transparent
        };
        foreach (var percent in percents)
        {
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
        }

        return panel;
    }

    public static Panel CreateMetricCard(string panelName, string titleName, string valueName, string title, string value, Color accent)
    {
        var panel = CreatePanel(panelName);
        AppTheme.StyleCard(panel);
        AppTheme.RoundPanelCorners(panel);
        panel.MinimumSize = new Size(220, 120);

        var bar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 6,
            BackColor = accent
        };

        var content = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            BackColor = Color.Transparent,
            Padding = new Padding(16, 10, 10, 10)
        };

        content.Controls.Add(CreateLabel(titleName, title, AppTheme.FontBodyBold, AppTheme.TextMuted), 0, 0);
        content.Controls.Add(CreateLabel(valueName, value, AppTheme.FontKpi, AppTheme.TextPrimary), 0, 1);

        panel.Controls.Add(content);
        panel.Controls.Add(bar);
        return panel;
    }

    public static PictureBox CreatePictureBox(string name)
    {
        return new PictureBox
        {
            Name = name,
            BackColor = Color.FromArgb(233, 239, 248),
            BorderStyle = BorderStyle.FixedSingle,
            SizeMode = PictureBoxSizeMode.Zoom,
            Width = 160,
            Height = 160,
            Margin = new Padding(0, 0, 0, 12)
        };
    }

    public static Chart CreateChart(string name)
    {
        var chart = new Chart
        {
            Name = name,
            Dock = DockStyle.Fill,
            Palette = ChartColorPalette.BrightPastel
        };

        chart.ChartAreas.Add(new ChartArea("DefaultArea")
        {
            AxisX = { MajorGrid = { Enabled = false } },
            AxisY = { MajorGrid = { LineColor = AppTheme.Border } }
        });

        chart.Legends.Add(new Legend("DefaultLegend")
        {
            Docking = Docking.Bottom
        });

        return chart;
    }

    public static void BindRevenueSeries(Chart chart)
    {
        chart.Series.Clear();
        var series = new Series("Doanh thu")
        {
            ChartType = SeriesChartType.Column,
            Color = AppTheme.Accent
        };
        series.Points.AddXY("Th1", 42);
        series.Points.AddXY("Th2", 48);
        series.Points.AddXY("Th3", 51);
        series.Points.AddXY("Th4", 37);
        chart.Series.Add(series);
    }

    public static void ShowChildForm(Panel host, Form child)
    {
        foreach (Control control in host.Controls)
        {
            control.Dispose();
        }

        host.Controls.Clear();
        child.TopLevel = false;
        child.FormBorderStyle = FormBorderStyle.None;
        child.Dock = DockStyle.Fill;
        host.Controls.Add(child);
        child.Show();
    }
}
