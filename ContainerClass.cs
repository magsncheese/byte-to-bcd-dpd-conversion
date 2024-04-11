namespace lab3{
      public class classContainer : ICompValueAbstract {

    private uint bOrD;
    public BCD bcd;
    public DPD dpd;

    //where it takes in a list of byts and it checks the first byte to see if its a 0 or 1 and based on that it creates a b or d wit the other 4 bytes
    //constructor
    public classContainer( List<byte> fiveBytes ) : base ( fiveBytes.Skip( 1 ).ToList() ){

        //0 == b | 1 == D
        bOrD = ( uint )fiveBytes[0];
        bcd = new BCD( fiveBytes.Skip( 1 ).ToList() );
        dpd = new DPD( fiveBytes.Skip( 1 ).ToList() );
        //IF NOT 0 OR 1 COUT A MESSAGE OR SOMETHIN IDK
    }

    override public void Decode(){

        //this will call the binary encrptying
        //i need to decrpyt in each of these and also have anther one in the class??? idk yet
        if( bOrD == 0 ){

            //call bcd
            bcd.Decode();
            Val = bcd.Val;

        }else if( bOrD == 1 ){

            //call dcd
            dpd.Decode();
            Val = dpd.Val;

        }else{
            Console.WriteLine("WOMP WOMP ur typeByte if wrong you FUCKING LOSER" );
        }
    }

}}
