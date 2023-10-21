namespace Final.Models;

public class Keep
{
    public int id { get; set; }
    public string creatorId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string img { get; set; }
    public int views { get; set; }
    public int kept { get; set; }
    public Account creator { get; set; }
}

public class KeepViewModel : Keep
{
    public int vaultKeepId { get; set; }
    public Boolean isPrivate { get; set; }
}