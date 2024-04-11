using System.Runtime.InteropServices.Marshalling;

namespace lab3{
    public class DPD : ICompValueAbstract {

    public DPD( List<byte> listOfBytes ) : base( listOfBytes ) { ; }

    public override void Decode() {

        //unpacked = decrypted
        //packed = encrypted
        //for ach set of 4 bits, can be any of those digits (0-7)
        //letters correspond to bits
        //unpack u can cut off the 0's and thats what makes it packed
            //get each bit

        //big decode - pulls out sets of 10 bits and calls the smaller decode on them bc u have to deode 10 bits at a time
        //12 bts but u ignore the upper 2, thats why its 10 at a time ==== u want the lower 10 bits

        //simular loop in bcd where it counts down 
        //20 bc it counts 5 bytes
        string number = "";
        for( int i = 20; i >= 0; i -= 10 ) {

            //?????????????????????????????
            //right shifting raw by i, then masking 
            number += SmolDude( ( Raw >>i ) & 0x3FF );

        }

        Val = Convert.ToUInt32( number );
    }

    private string SmolDude( uint bits ){

        string dig1 = "0", dig2 = "0", dig3 = "0"; 

        if( ( bits & 0x8 ) == 0 ) { //row 1 of chart vv
            dig1 = ( 0 + ( bits & 0x380 ) / 128 ).ToString();
            dig2 = ( 0 + ( bits & 0x70  ) / 16  ).ToString();
            dig3 = ( 0 + ( bits & 0x7   )       ).ToString();

        }else if( ( bits & 0xE ) == 0x8 ){ //row 2 vv
            dig1 = ( 0 + ( bits & 0x380 ) / 128 ).ToString();
            dig2 = ( 0 + ( bits & 0x70  ) / 16  ).ToString();
            dig3 = ( 8 + ( bits & 0x1   )       ).ToString();

        }else if( ( bits & 0xE ) == 0xA ){ //row 3 v
            dig1 = ( 0 + ( bits & 0x380 ) / 128 ).ToString();  //c
            dig2 = ( 8 + ( bits & 0x10  ) / 16  ).ToString();  //f
            dig3 = ( 0 + (( bits & 0x60 ) / 16  ) + ( bits & 0x1 ) ).ToString();  //gh i

        }else if( ( bits & 0xE ) == 0xC ){  //row 4 v
            dig1 = ( 8 + ( bits & 0x80  ) / 128 ).ToString();  //c
            dig2 = ( 0 + ( bits & 0x70  ) / 16  ).ToString();  //def
            dig3 = ( 0 + (( bits & 0x300) / 128 ) + ( bits & 0x1 ) ).ToString();  //gh i

        }else if( ( ( bits & 0xE ) == 0xE ) && ( ( bits & 0x60 ) == 0 ) ){   //row 5 v
            dig1 = ( 8 + ( bits & 0x80  ) / 128 ).ToString();  //c
            dig2 = ( 8 + ( bits & 0x10  ) / 16  ).ToString();  //f
            dig3 = ( 0 + ( ( bits & 0x1 ) + ( bits & 0x300 ) ) / 128 ).ToString();  //gh i

        }else if( ( ( bits & 0xE ) == 0xE ) && ( ( bits & 0x60 ) == 0x20 ) ){ // row 6 v
            dig1 = ( 8 + ( bits & 0x80  ) / 128 ).ToString();  //c 
            dig2 = ( 0 + ((bits & 0x300 )  / 128 ) + ( bits & 0x10 ) / 16 ).ToString();  //def
            dig3 = ( 8 + ( bits & 0x1   )       ).ToString();  //i
        }else if( ( ( bits & 0xE ) == 0xE ) && ( ( bits & 0x60 ) == 0x40 ) ){  //row 7 v
            dig1 = ( 0 + ( bits & 0x380 ) / 128 ).ToString(); //abc
            dig2 = ( 8 + ( bits & 0x10  ) / 16  ).ToString(); //f
            dig3 = ( 8 + ( bits & 0x1   )       ).ToString();
        }else{  //row 8 v
            dig1 = ( 8 + ( bits & 0x80  ) / 128 ).ToString(); //c
            dig2 = ( 8 + ( bits & 0x10  ) / 16  ).ToString(); // f
            dig3 = ( 8 + ( bits & 0x1   )       ).ToString();

        }

        return ( dig1 + dig2 + dig3 );
    }
}
}
