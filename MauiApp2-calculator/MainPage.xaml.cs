using Microsoft.Maui.Controls;

namespace MauiApp2_calculator;

public partial class MainPage : ContentPage
{
    string currentInput = "";

    public MainPage()
    {
        InitializeComponent();
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            currentInput += button.Text;
            DisplayLabel.Text = currentInput;
        }
    }

    void OnClearClicked(object sender, EventArgs e)
    {
        currentInput = "";
        DisplayLabel.Text = "0";
    }

    void OnOperatorClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            currentInput += $" {button.Text} ";
            DisplayLabel.Text = currentInput;
        }
    }

    void OnCalculateClicked(object sender, EventArgs e)
    {
        DisplayLabel.Text = "Výsledek";
    }

    void OnLightModeClicked(object sender, EventArgs e)
    {
        // Světlý režim
        this.BackgroundColor = Color.FromArgb("#F5F5F5");
        DisplayFrame.BackgroundColor = Colors.White;
        DisplayFrame.BorderColor = Color.FromArgb("#2196F3");
        DisplayLabel.TextColor = Color.FromArgb("#2196F3");

        SetButtonColors(
            background: Colors.White,
            text: Colors.Black,
            operatorBackground: Color.FromArgb("#E3F2FD"),
            operatorText: Colors.Black,
            cBackground: Color.FromArgb("#FF9800"),
            cText: Colors.White,
            equalsBackground: Color.FromArgb("#4CAF50"),
            equalsText: Colors.White
        );
    }

    void OnDarkModeClicked(object sender, EventArgs e)
    {
        // Tmavý režim
        this.BackgroundColor = Color.FromArgb("#212121");
        DisplayFrame.BackgroundColor = Color.FromArgb("#424242");
        DisplayFrame.BorderColor = Color.FromArgb("#90CAF9");
        DisplayLabel.TextColor = Colors.White;

        SetButtonColors(
            background: Colors.Black,
            text: Colors.White,
            operatorBackground: Color.FromArgb("#424242"),
            operatorText: Colors.White,
            cBackground: Color.FromArgb("#FF9800"),
            cText: Colors.Black,
            equalsBackground: Color.FromArgb("#388E3C"),
            equalsText: Colors.White
        );
    }

    void SetButtonColors(
        Color background,
        Color text,
        Color operatorBackground,
        Color operatorText,
        Color cBackground,
        Color cText,
        Color equalsBackground,
        Color equalsText)
    {
        // Číselná tlačítka
        Btn0.BackgroundColor = background; Btn0.TextColor = text;
        Btn1.BackgroundColor = background; Btn1.TextColor = text;
        Btn2.BackgroundColor = background; Btn2.TextColor = text;
        Btn3.BackgroundColor = background; Btn3.TextColor = text;
        Btn4.BackgroundColor = background; Btn4.TextColor = text;
        Btn5.BackgroundColor = background; Btn5.TextColor = text;
        Btn6.BackgroundColor = background; Btn6.TextColor = text;
        Btn7.BackgroundColor = background; Btn7.TextColor = text;
        Btn8.BackgroundColor = background; Btn8.TextColor = text;
        Btn9.BackgroundColor = background; Btn9.TextColor = text;
        BtnComma.BackgroundColor = background; BtnComma.TextColor = text;
        BtnLeft.BackgroundColor = background; BtnLeft.TextColor = text;
        BtnRight.BackgroundColor = background; BtnRight.TextColor = text;

        // Operátory
        BtnPlus.BackgroundColor = operatorBackground; BtnPlus.TextColor = operatorText;
        BtnMinus.BackgroundColor = operatorBackground; BtnMinus.TextColor = operatorText;
        BtnMultiply.BackgroundColor = operatorBackground; BtnMultiply.TextColor = operatorText;
        BtnDivide.BackgroundColor = operatorBackground; BtnDivide.TextColor = operatorText;

        // C
        BtnC.BackgroundColor = cBackground; BtnC.TextColor = cText;

        // =
        BtnEquals.BackgroundColor = equalsBackground; BtnEquals.TextColor = equalsText;
    }
}
