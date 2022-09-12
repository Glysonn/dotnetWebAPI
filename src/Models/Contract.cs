namespace src.Models;

public class Contract
{
    //  Constructor
    public Contract()
    {
        this.CreateData = DateTime.Now;
        this.Value = 0;
        this.TokenId = "00000";
        this.WasPayed = false;
    }
    public Contract(double Value, string TokenId)
    {
        this.CreateData = DateTime.Now;
        this.Value = Value;
        this.TokenId = TokenId;
    }
    public DateTime CreateData { get; set; }
    public int Id { get; set; }
    //  foreign key
    public int PersonID { get; set; }
    public string TokenId { get; set; }
    public double Value { get; set; }
    public bool WasPayed { get; set; }

}