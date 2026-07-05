namespace CalculatorPro;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Panel titleBar;
    private Label titleLabel;
    private Label subtitleLabel;
    private Button minimizeButton;
    private Button closeButton;
    private Panel contentPanel;
    private Panel displayCard;
    private Label expressionLabel;
    private Label displayLabel;
    private Panel keypadCard;
    private TableLayoutPanel keypadGrid;
    private Button clearButton;
    private Button signButton;
    private Button percentButton;
    private Button divideButton;
    private Button sevenButton;
    private Button eightButton;
    private Button nineButton;
    private Button multiplyButton;
    private Button fourButton;
    private Button fiveButton;
    private Button sixButton;
    private Button subtractButton;
    private Button oneButton;
    private Button twoButton;
    private Button threeButton;
    private Button addButton;
    private Button zeroButton;
    private Button decimalButton;
    private Button backspaceButton;
    private Button equalsButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        titleBar = new Panel();
        titleLabel = new Label();
        subtitleLabel = new Label();
        minimizeButton = new Button();
        closeButton = new Button();
        contentPanel = new Panel();
        displayCard = new Panel();
        expressionLabel = new Label();
        displayLabel = new Label();
        keypadCard = new Panel();
        keypadGrid = new TableLayoutPanel();
        clearButton = new Button();
        signButton = new Button();
        percentButton = new Button();
        divideButton = new Button();
        sevenButton = new Button();
        eightButton = new Button();
        nineButton = new Button();
        multiplyButton = new Button();
        fourButton = new Button();
        fiveButton = new Button();
        sixButton = new Button();
        subtractButton = new Button();
        oneButton = new Button();
        twoButton = new Button();
        threeButton = new Button();
        addButton = new Button();
        zeroButton = new Button();
        decimalButton = new Button();
        backspaceButton = new Button();
        equalsButton = new Button();
        titleBar.SuspendLayout();
        contentPanel.SuspendLayout();
        displayCard.SuspendLayout();
        keypadCard.SuspendLayout();
        keypadGrid.SuspendLayout();
        SuspendLayout();

        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(10, 15, 24);
        ClientSize = new Size(400, 680);
        Controls.Add(contentPanel);
        Controls.Add(titleBar);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.None;
        MinimumSize = new Size(380, 640);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calculator Pro";

        titleBar.Controls.Add(closeButton);
        titleBar.Controls.Add(minimizeButton);
        titleBar.Controls.Add(subtitleLabel);
        titleBar.Controls.Add(titleLabel);
        titleBar.Dock = DockStyle.Top;
        titleBar.Height = 74;
        titleBar.Padding = new Padding(24, 16, 20, 16);
        titleBar.MouseDown += DragWindow;

        titleLabel.AutoSize = true;
        titleLabel.Location = new Point(24, 14);
        titleLabel.Margin = new Padding(0);
        titleLabel.Text = "Calculator Pro";
        titleLabel.MouseDown += DragWindow;

        subtitleLabel.AutoSize = true;
        subtitleLabel.Location = new Point(24, 39);
        subtitleLabel.Margin = new Padding(0);
        subtitleLabel.Text = "Keyboard supported  ·  Fast & precise";
        subtitleLabel.MouseDown += DragWindow;

        closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        closeButton.FlatAppearance.BorderSize = 0;
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        closeButton.ForeColor = Color.White;
        closeButton.Location = new Point(334, 16);
        closeButton.Margin = new Padding(0);
        closeButton.Size = new Size(46, 32);
        closeButton.Text = "x";
        closeButton.Click += CloseClicked;

        minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        minimizeButton.FlatAppearance.BorderSize = 0;
        minimizeButton.FlatStyle = FlatStyle.Flat;
        minimizeButton.Font = new Font("Calibri  Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
        minimizeButton.ForeColor = Color.White;
        minimizeButton.Location = new Point(282, 16);
        minimizeButton.Margin = new Padding(0);
        minimizeButton.Size = new Size(46, 32);
        minimizeButton.Text = "-";
        minimizeButton.Click += MinimizeClicked;

        contentPanel.BackColor = Color.Transparent;
        contentPanel.Controls.Add(keypadCard);
        contentPanel.Controls.Add(displayCard);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Padding = new Padding(24, 8, 24, 24);

        displayCard.Controls.Add(displayLabel);
        displayCard.Controls.Add(expressionLabel);
        displayCard.Dock = DockStyle.Top;
        displayCard.Height = 190;
        displayCard.Margin = new Padding(0, 0, 0, 18);
        displayCard.Padding = new Padding(28, 26, 28, 24);

        expressionLabel.Dock = DockStyle.Top;
        expressionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        expressionLabel.ForeColor = Color.FromArgb(155, 172, 198);
        expressionLabel.Location = new Point(28, 26);
        expressionLabel.Margin = new Padding(0);
        expressionLabel.Name = "expressionLabel";
        expressionLabel.Size = new Size(1024, 28);
        expressionLabel.Text = "";
        expressionLabel.TextAlign = ContentAlignment.MiddleRight;

        displayLabel.Dock = DockStyle.Fill;
        displayLabel.Font = new Font("Segoe UI Semibold", 34F, FontStyle.Bold, GraphicsUnit.Point);
        displayLabel.ForeColor = Color.White;
        displayLabel.Location = new Point(28, 54);
        displayLabel.Margin = new Padding(0);
        displayLabel.Name = "displayLabel";
        displayLabel.Size = new Size(1024, 112);
        displayLabel.Text = "0";
        displayLabel.TextAlign = ContentAlignment.MiddleRight;

        keypadCard.Controls.Add(keypadGrid);
        keypadCard.Dock = DockStyle.Fill;
        keypadCard.Padding = new Padding(18);

        keypadGrid.ColumnCount = 4;
        keypadGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        keypadGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        keypadGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        keypadGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        keypadGrid.Dock = DockStyle.Fill;
        keypadGrid.Location = new Point(18, 18);
        keypadGrid.Margin = new Padding(0);
        keypadGrid.Name = "keypadGrid";
        keypadGrid.RowCount = 5;
        keypadGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        keypadGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        keypadGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        keypadGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        keypadGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

        ConfigureButton(clearButton, "C", ClearClicked, 0, 0, Color.FromArgb(63, 72, 94));
        ConfigureButton(signButton, "±", SignClicked, 0, 1, Color.FromArgb(44, 54, 74));
        ConfigureButton(percentButton, "%", PercentClicked, 0, 2, Color.FromArgb(44, 54, 74));
        ConfigureButton(divideButton, "÷", OperationClicked, 0, 3, Color.FromArgb(0, 148, 136));

        ConfigureButton(sevenButton, "7", DigitClicked, 1, 0, Color.FromArgb(33, 41, 57));
        ConfigureButton(eightButton, "8", DigitClicked, 1, 1, Color.FromArgb(33, 41, 57));
        ConfigureButton(nineButton, "9", DigitClicked, 1, 2, Color.FromArgb(33, 41, 57));
        ConfigureButton(multiplyButton, "×", OperationClicked, 1, 3, Color.FromArgb(0, 148, 136));

        ConfigureButton(fourButton, "4", DigitClicked, 2, 0, Color.FromArgb(33, 41, 57));
        ConfigureButton(fiveButton, "5", DigitClicked, 2, 1, Color.FromArgb(33, 41, 57));
        ConfigureButton(sixButton, "6", DigitClicked, 2, 2, Color.FromArgb(33, 41, 57));
        ConfigureButton(subtractButton, "-", OperationClicked, 2, 3, Color.FromArgb(0, 148, 136));

        ConfigureButton(oneButton, "1", DigitClicked, 3, 0, Color.FromArgb(33, 41, 57));
        ConfigureButton(twoButton, "2", DigitClicked, 3, 1, Color.FromArgb(33, 41, 57));
        ConfigureButton(threeButton, "3", DigitClicked, 3, 2, Color.FromArgb(33, 41, 57));
        ConfigureButton(addButton, "+", OperationClicked, 3, 3, Color.FromArgb(0, 148, 136));

        ConfigureButton(zeroButton, "0", DigitClicked, 4, 0, Color.FromArgb(33, 41, 57));
        ConfigureButton(decimalButton, ".", DecimalClicked, 4, 1, Color.FromArgb(33, 41, 57));
        ConfigureButton(backspaceButton, "⌫", BackspaceClicked, 4, 2, Color.FromArgb(63, 72, 94));
        ConfigureButton(equalsButton, "=", EqualsClicked, 4, 3, Color.FromArgb(255, 158, 67));

        keypadGrid.Controls.Add(clearButton, 0, 0);
        keypadGrid.Controls.Add(signButton, 1, 0);
        keypadGrid.Controls.Add(percentButton, 2, 0);
        keypadGrid.Controls.Add(divideButton, 3, 0);
        keypadGrid.Controls.Add(sevenButton, 0, 1);
        keypadGrid.Controls.Add(eightButton, 1, 1);
        keypadGrid.Controls.Add(nineButton, 2, 1);
        keypadGrid.Controls.Add(multiplyButton, 3, 1);
        keypadGrid.Controls.Add(fourButton, 0, 2);
        keypadGrid.Controls.Add(fiveButton, 1, 2);
        keypadGrid.Controls.Add(sixButton, 2, 2);
        keypadGrid.Controls.Add(subtractButton, 3, 2);
        keypadGrid.Controls.Add(oneButton, 0, 3);
        keypadGrid.Controls.Add(twoButton, 1, 3);
        keypadGrid.Controls.Add(threeButton, 2, 3);
        keypadGrid.Controls.Add(addButton, 3, 3);
        keypadGrid.Controls.Add(zeroButton, 0, 4);
        keypadGrid.Controls.Add(decimalButton, 1, 4);
        keypadGrid.Controls.Add(backspaceButton, 2, 4);
        keypadGrid.Controls.Add(equalsButton, 3, 4);

        titleBar.ResumeLayout(false);
        titleBar.PerformLayout();
        contentPanel.ResumeLayout(false);
        displayCard.ResumeLayout(false);
        keypadCard.ResumeLayout(false);
        keypadGrid.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static void ConfigureButton(Button button, string text, EventHandler clickHandler, int row, int column, Color backgroundColor)
    {
        button.Dock = DockStyle.Fill;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Font = new Font("Segoe UI Semibold", text == "=" ? 16F : 14F, FontStyle.Bold, GraphicsUnit.Point);
        button.ForeColor = Color.White;
        button.Margin = new Padding(8);
        button.Name = $"{text}Button";
        button.Text = text;
        button.BackColor = backgroundColor;
        button.Click += clickHandler;
        button.TabStop = false;
    }
}
