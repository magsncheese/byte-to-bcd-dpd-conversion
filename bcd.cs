namespace lab3{
    //binary
public class BCD : ICompValueAbstract {

    //need a construcor - keep empty for dpd too
    //might need { ; }
    //like a constructor for two things
    public BCD( List<byte> listOfBytes ) : base( listOfBytes ) { ; }

    public override void Decode(){

        uint temp = Raw;

        string number = "";  //convert function

        //go over each byte
        for( int i = 7; i >= 0; i-- ){

            //add digit and shift
            //this i needs to have something added to it but idk what yet
            //dont need to index bc we are alraedy shifting
            number += ( temp >>( i * 4 ) & 0xF ).ToString();
                
            //val is a member var so i dont have to return it
            Val = Convert.ToUInt32( number );
        }
    }
}
}
