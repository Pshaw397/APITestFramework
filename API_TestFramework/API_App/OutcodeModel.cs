
public class OutcodeResponse
{
    public int status { get; set; }
    public Outcode result { get; set; }
}

public class Outcode
{
    public string outcode { get; set; }
    public float longitude { get; set; }
    public float latitude { get; set; }
    public int northings { get; set; }
    public int eastings { get; set; }
    public string[] admin_district { get; set; }
    public string[] parish { get; set; }
    public string[] admin_county { get; set; }
    public string[] admin_ward { get; set; }
    public string[] country { get; set; }
}
