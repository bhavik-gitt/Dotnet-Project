using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace CalculatorPro;

public partial class Form1 : Form
{
    private decimal _storedValue;
    private string? _pendingOperation;
    private bool _hasStoredValue;
    private bool _startNewEntry = true;
    private bool _isError;

    public Form1()
    {
        InitializeComponent();
        DoubleBuffered = true;
        KeyPreview = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        ApplyVisualState();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ApplyRoundCorners();
        UpdateDisplay(0m);
        UpdateExpression(string.Empty);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        ApplyRoundCorners();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using var backgroundBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(10, 15, 24), Color.FromArgb(24, 31, 46), LinearGradientMode.Vertical);
        e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);

        using var topGlowBrush = new SolidBrush(Color.FromArgb(28, 88, 166, 255));
        using var bottomGlowBrush = new SolidBrush(Color.FromArgb(20, 0, 194, 149));
        e.Graphics.FillEllipse(topGlowBrush, -120, -120, 340, 340);
        e.Graphics.FillEllipse(bottomGlowBrush, ClientSize.Width - 240, ClientSize.Height - 180, 300, 300);
    }

    private void ApplyVisualState()
    {
        StyleControlTree(this);

        titleBar.BackColor = Color.FromArgb(15, 20, 10);
        displayCard.BackColor = Color.FromArgb(20, 26, 39);
        keypadCard.BackColor = Color.FromArgb(20, 26, 39);

        titleLabel.ForeColor = Color.White;
        subtitleLabel.ForeColor = Color.FromArgb(170, 186, 208);
        expressionLabel.ForeColor = Color.FromArgb(155, 172, 198);
        displayLabel.ForeColor = Color.White;

        titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
        subtitleLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
        expressionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        displayLabel.Font = new Font("Segoe UI Semibold", 34F, FontStyle.Bold, GraphicsUnit.Point);

        SetAccentPalette();
    }

    private void StyleControlTree(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;
                button.Font = new Font("Segoe UI Semibold", button == equalsButton ? 16F : 14F, FontStyle.Bold, GraphicsUnit.Point);
                button.ForeColor = Color.White;
                button.BackColor = Color.FromArgb(33, 41, 57);
                button.Tag = button.Text;
                button.MouseEnter += OnButtonMouseEnter;
                button.MouseLeave += OnButtonMouseLeave;
                ApplyRoundedRegion(button, 16);
            }
            else if (control is Panel panel)
            {
                panel.BackColor = Color.FromArgb(26, 32, 46);
                ApplyRoundedRegion(panel, 24);
                StyleControlTree(panel);
            }
            else
            {
                StyleControlTree(control);
            }
        }
    }

    private void SetAccentPalette()
    {
        clearButton.BackColor = Color.FromArgb(63, 72, 94);
        backspaceButton.BackColor = Color.FromArgb(63, 72, 94);
        percentButton.BackColor = Color.FromArgb(44, 54, 74);
        signButton.BackColor = Color.FromArgb(44, 54, 74);
        divideButton.BackColor = Color.FromArgb(0, 148, 136);
        multiplyButton.BackColor = Color.FromArgb(0, 148, 136);
        subtractButton.BackColor = Color.FromArgb(0, 148, 136);
        addButton.BackColor = Color.FromArgb(0, 148, 136);
        equalsButton.BackColor = Color.FromArgb(255, 158, 67);
    }

    private void OnButtonMouseEnter(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.BackColor = ControlPaint.Light(button.BackColor, 0.12f);
        }
    }

    private void OnButtonMouseLeave(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Tag is string role)
        {
            button.BackColor = role switch
            {
                "+" or "-" or "×" or "÷" => Color.FromArgb(0, 148, 136),
                "=" => Color.FromArgb(255, 158, 67),
                "C" or "⌫" => Color.FromArgb(63, 72, 94),
                "%" or "±" => Color.FromArgb(44, 54, 74),
                _ => Color.FromArgb(33, 41, 57)
            };
        }
    }

    private void ApplyRoundCorners()
    {
        using GraphicsPath path = CreateRoundRectPath(new Rectangle(0, 0, Width, Height), 26);
        Region = new Region(path);
    }

    private static void ApplyRoundedRegion(Control control, int radius)
    {
        if (control.Width <= 0 || control.Height <= 0)
        {
            return;
        }

        using GraphicsPath path = CreateRoundRectPath(new Rectangle(0, 0, control.Width, control.Height), radius);
        control.Region = new Region(path);
    }

    private static GraphicsPath CreateRoundRectPath(Rectangle bounds, int radius)
    {
        var path = new GraphicsPath();
        int diameter = radius * 2;

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }

    private static string FormatValue(decimal value)
    {
        return value % 1 == 0 ? value.ToString("0") : value.ToString("0.##########");
    }

    private decimal CurrentValue
    {
        get
        {
            if (_isError) return 0m;
            return decimal.TryParse(displayLabel.Text,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal value) ? value : 1m;
        }
    }

    // ── Display helpers ────────────────────────────────────────────────────────

    private void UpdateDisplay(decimal value)
    {
        displayLabel.ForeColor = Color.White;
        displayLabel.Text = FormatValue(value);
        AdjustDisplayFont();
    }

    private void UpdateExpression(string text)
    {
        expressionLabel.Text = text;
    }

    private void ShowError(string message)
    {
        _isError = true;
        displayLabel.ForeColor = Color.FromArgb(255, 100, 100);
        displayLabel.Text = message;
        _startNewEntry = true;
        AdjustDisplayFont();
    }

    private void AdjustDisplayFont()
    {
        int len = displayLabel.Text.Length;
        float size = len > 16 ? 18F :
                     len > 12 ? 22F :
                     len > 8  ? 28F : 34F;
        if (Math.Abs(displayLabel.Font.Size - size) > 0.01f)
            displayLabel.Font = new Font("Segoe UI Semibold", size, FontStyle.Bold, GraphicsUnit.Point);
    }

    // ── Digit / decimal input ──────────────────────────────────────────────────

    private void EnterDigit(string digit)
    {
        if (_isError) return;
        if (_startNewEntry || displayLabel.Text == "0")
        {
            displayLabel.Text = digit;
            _startNewEntry = false;
            AdjustDisplayFont();
            return;
        }
        displayLabel.Text += digit;
        AdjustDisplayFont();
    }

    private void DigitClicked(object? sender, EventArgs e)
    {
        if (sender is Button button)
            EnterDigit(button.Text);
    }

    private void DecimalClicked(object? sender, EventArgs e)
    {
        if (_isError) return;
        if (_startNewEntry)
        {
            displayLabel.Text = "0.";
            _startNewEntry = false;
            return;
        }
        if (!displayLabel.Text.Contains('.'))
            displayLabel.Text += '.';
    }

    // ── Edit actions ───────────────────────────────────────────────────────────

    private void BackspaceClicked(object? sender, EventArgs e)
    {
        if (_startNewEntry || _isError) return;

        if (displayLabel.Text.Length <= 1 || (displayLabel.Text.Length == 2 && displayLabel.Text.StartsWith('-')))
        {
            displayLabel.Text = "0";
            _startNewEntry = true;
            AdjustDisplayFont();
            return;
        }

        displayLabel.Text = displayLabel.Text[..^1];
        AdjustDisplayFont();
    }

    private void ClearClicked(object? sender, EventArgs e)
    {
        _storedValue = 0m;
        _pendingOperation = null;
        _hasStoredValue = false;
        _startNewEntry = true;
        _isError = false;
        UpdateDisplay(0m);
        UpdateExpression(string.Empty);
    }

    private void SignClicked(object? sender, EventArgs e)
    {
        if (_isError || displayLabel.Text == "0") return;
        displayLabel.Text = displayLabel.Text.StartsWith('-') ? displayLabel.Text[1..] : $"-{displayLabel.Text}";
        _startNewEntry = false;
    }

    private void PercentClicked(object? sender, EventArgs e)
    {
        if (_isError) return;
        decimal value = CurrentValue / 100m;
        UpdateDisplay(value);
        _startNewEntry = true;
    }

    // ── Arithmetic ─────────────────────────────────────────────────────────────

    private void OperationClicked(object? sender, EventArgs e)
    {
        if (_isError) return;
        if (sender is Button button)
            ApplyPendingOperation(button.Text);
    }

    private bool IsDivisionByZero() =>
        _pendingOperation == "÷" && CurrentValue == 0m;

    private void EqualsClicked(object? sender, EventArgs e)
    {
        if (_isError || string.IsNullOrWhiteSpace(_pendingOperation)) return;

        if (IsDivisionByZero())
        {
            ShowError("Cannot ÷ 0");
            return;
        }

        decimal result = ExecuteOperation(_storedValue, CurrentValue, _pendingOperation);
        UpdateExpression($"{FormatValue(_storedValue)} {_pendingOperation} {FormatValue(CurrentValue)} =");
        UpdateDisplay(result);
        _storedValue = result;
        _pendingOperation = null;
        _hasStoredValue = false;
        _startNewEntry = true;
    }

    private void ApplyPendingOperation(string operation)
    {
        if (_isError) return;

        if (!_hasStoredValue)
        {
            _storedValue = CurrentValue;
            _hasStoredValue = true;
            _pendingOperation = operation;
            _startNewEntry = true;
            UpdateExpression($"{FormatValue(_storedValue)} {operation}");
            return;
        }

        if (!_startNewEntry && _pendingOperation is not null)
        {
            if (IsDivisionByZero())
            {
                ShowError("Cannot ÷ 0");
                return;
            }

            decimal result = ExecuteOperation(_storedValue, CurrentValue, _pendingOperation);
            _storedValue = result;
            UpdateDisplay(result);
        }

        _pendingOperation = operation;
        _startNewEntry = true;
        UpdateExpression($"{FormatValue(_storedValue)} {operation}");
    }

    private static decimal ExecuteOperation(decimal left, decimal right, string operation)
    {
        return operation switch
        {
            "+" => left + right,
            "-" => left - right,
            "×" => left * right,
            "÷" when right != 0m => left / right,
            _ => right
        };
    }

    // ── Keyboard support ───────────────────────────────────────────────────────

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        bool handled = true;
        switch (e.KeyCode)
        {
            case Keys.D0: case Keys.NumPad0: EnterDigit("0"); break;
            case Keys.D1: case Keys.NumPad1: EnterDigit("1"); break;
            case Keys.D2: case Keys.NumPad2: EnterDigit("2"); break;
            case Keys.D3: case Keys.NumPad3: EnterDigit("3"); break;
            case Keys.D4: case Keys.NumPad4: EnterDigit("4"); break;
            case Keys.D5:
                if (e.Shift) PercentClicked(null, EventArgs.Empty);
                else EnterDigit("5");
                break;
            case Keys.NumPad5: EnterDigit("5"); break;
            case Keys.D6: case Keys.NumPad6: EnterDigit("6"); break;
            case Keys.D7: case Keys.NumPad7: EnterDigit("7"); break;
            case Keys.D8:
                if (e.Shift) ApplyPendingOperation("×");
                else EnterDigit("8");
                break;
            case Keys.NumPad8: EnterDigit("8"); break;
            case Keys.D9: case Keys.NumPad9: EnterDigit("9"); break;
            case Keys.OemPeriod:
            case Keys.Decimal: DecimalClicked(null, EventArgs.Empty); break;
            case Keys.Add: ApplyPendingOperation("+"); break;
            case Keys.Subtract:
            case Keys.OemMinus: ApplyPendingOperation("-"); break;
            case Keys.Multiply: ApplyPendingOperation("×"); break;
            case Keys.Divide:
            case Keys.OemQuestion: ApplyPendingOperation("÷"); break;
            case Keys.Oemplus:
                if (e.Shift) ApplyPendingOperation("+");
                else EqualsClicked(null, EventArgs.Empty);
                break;
            case Keys.Enter: EqualsClicked(null, EventArgs.Empty); break;
            case Keys.Escape:
            case Keys.Delete: ClearClicked(null, EventArgs.Empty); break;
            case Keys.Back: BackspaceClicked(null, EventArgs.Empty); break;
            default: handled = false; break;
        }

        if (handled)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    // ── Window chrome ──────────────────────────────────────────────────────────

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    private static extern nint SendMessage(nint hWnd, int msg, int wParam, int lParam);

    private const int WmNclbuttondown = 0xA1;
    private const int Htcaption = 0x21;

    private void DragWindow(object? sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(Handle, WmNclbuttondown, Htcaption, 0);
    }

    private void CloseClicked(object? sender, EventArgs e) => Close();

    private void MinimizeClicked(object? sender, EventArgs e) => WindowState = FormWindowState.Minimized;
}
