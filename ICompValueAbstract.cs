namespace lab3{
    //done?

using System.Dynamic;
public abstract class ICompValueAbstract : ICompValue {

    //constructor that mtakes a list of bytes and puts them in little endian
    //dont have to do that
    public uint Raw {get; set;}
    public uint Val {get; set;}

    public ICompValueAbstract( List<byte> bytes ){
        //shifting bc big endian
        Raw = (uint)bytes[0] <<24 | (uint)bytes[1] <<16 | (uint)bytes[2] <<8 | (uint)bytes[3];
        Val = Raw;
    }

    public int CompareTo( object obj ){

        if( obj == null ) return 1;

        ICompValue otherCompValue = obj as ICompValue;
        //(icomopval)(obj)

        if (otherCompValue != null)
        {
            if (this.Val < otherCompValue.Val)
                return -1;
            else if (this.Val == otherCompValue.Val)
                return 0;
            else
                return 1;
        } else {
            throw new ArgumentException("Object is not a valid ICompValue");
        }
    }

    //took off abstract, might need it back
        //public abstract void Decode();
    public abstract void Decode();
}

}
