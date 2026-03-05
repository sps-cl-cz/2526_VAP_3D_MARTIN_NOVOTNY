namespace piskvorky;

public partial class MainPage : ContentPage
{
    private Button[,] buttons = new Button[3, 3];
    private string currentPlayer = "X";

    public MainPage()
    {
        InitializeComponent();
        BackgroundColor = Color.FromArgb("#f5f7fa"); 
        CreateBoard();
        TurnLabel.TextColor = Color.FromArgb("#22223b"); 
    }

    private void CreateBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var button = new Button
                {
                    FontSize = 32,
                    BackgroundColor = Color.FromArgb("#e0e1dd"), 
                    CornerRadius = 10,
                    TextColor = Color.FromArgb("#22223b") 
                };
                button.Clicked += OnButtonClicked;
                buttons[row, col] = button;
                GameGrid.Add(button, col, row);
            }
        }
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (!string.IsNullOrEmpty(button.Text))
            return;

        button.Text = currentPlayer;
        button.TextColor = currentPlayer == "X" ? Color.FromArgb("#0077b6") : Color.FromArgb("#d90429");
        button.BackgroundColor = Color.FromArgb("#f8f9fa"); 

        if (CheckWinner())
        {
            DisplayAlert("Konec hry", $"Vyhrál hráč {currentPlayer}", "OK");
            DisableBoard();
            return;
        }
        if (IsBoardFull())
        {
            DisplayAlert("Konec hry", "Remíza!", "OK");
            return;
        }
        currentPlayer = currentPlayer == "X" ? "O" : "X";
        TurnLabel.Text = $"Na tahu: {currentPlayer}";
        TurnLabel.TextColor = currentPlayer == "X" ? Color.FromArgb("#0077b6") : Color.FromArgb("#d90429");
    }

    private bool CheckWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (buttons[i, 0].Text == currentPlayer &&
                buttons[i, 1].Text == currentPlayer &&
                buttons[i, 2].Text == currentPlayer)
                return true;
            if (buttons[0, i].Text == currentPlayer &&
                buttons[1, i].Text == currentPlayer &&
                buttons[2, i].Text == currentPlayer)
                return true;
        }
        if (buttons[0, 0].Text == currentPlayer &&
            buttons[1, 1].Text == currentPlayer &&
            buttons[2, 2].Text == currentPlayer)
            return true;
        if (buttons[0, 2].Text == currentPlayer &&
            buttons[1, 1].Text == currentPlayer &&
            buttons[2, 0].Text == currentPlayer)
            return true;
        return false;
    }

    private bool IsBoardFull()
    {
        foreach (var button in buttons)
        {
            if (string.IsNullOrEmpty(button.Text))
                return false;
        }
        return true;
    }

    private void DisableBoard()
    {
        foreach (var button in buttons)
            button.IsEnabled = false;
    }

    private void NewGame_Clicked(object sender, EventArgs e)
    {
        currentPlayer = "X";
        TurnLabel.Text = "Na tahu: X";
        TurnLabel.TextColor = Color.FromArgb("#0077b6");
        foreach (var button in buttons)
        {
            button.Text = "";
            button.IsEnabled = true;
            button.BackgroundColor = Color.FromArgb("#e0e1dd");
            button.TextColor = Color.FromArgb("#22223b");
        }
        BackgroundColor = Color.FromArgb("#f5f7fa");
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            BackgroundColor = Color.FromArgb("#22223b"); 
            TurnLabel.TextColor = Color.FromArgb("#f8f9fa"); 
            foreach (var button in buttons)
            {
                button.BackgroundColor = Color.FromArgb("#4a4e69"); 
                button.TextColor = Color.FromArgb("#f8f9fa"); 
            }
        }
        else
        {
            BackgroundColor = Color.FromArgb("#f5f7fa");
            TurnLabel.TextColor = Color.FromArgb("#22223b");
            foreach (var button in buttons)
            {
                button.BackgroundColor = Color.FromArgb("#e0e1dd");
                button.TextColor = Color.FromArgb("#22223b");
            }
        }
    }
}
