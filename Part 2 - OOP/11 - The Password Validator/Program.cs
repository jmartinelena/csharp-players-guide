while (true)
{
    Console.Write("Enter a password (or exit to break out of the loop): ");
    string pass = Console.ReadLine() ?? "exit";
    if (pass == "exit") break;
    PasswordValidator password = new PasswordValidator(pass);
    Console.WriteLine(password.Validate() ? "The password is valid" : "The password is not valid");
}

class PasswordValidator
{
    private string _password;
    public PasswordValidator(string password)
    {
        _password = password;
    }
    public bool Validate()
    {
        string pass = _password;
        bool correctLength = (pass.Length >= 6 && pass.Length <= 13);
        bool hasLower = false;
        bool hasUpper = false;
        bool hasNumber = false;
        bool hasIllegal = false;
        foreach (char chara in pass)
        {
            if (char.IsUpper(chara)) hasUpper = true;
            if (char.IsLower(chara)) hasLower = true;
            if (char.IsDigit(chara)) hasNumber = true;
            if (chara == 'T' || chara == '&') hasIllegal = true;
        }
        bool isValid = correctLength && hasLower && hasUpper && hasNumber && !hasIllegal;
        return isValid;
    }
}
