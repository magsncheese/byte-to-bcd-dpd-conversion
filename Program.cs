//Name: Margaret Kelley
//NetID: mkelle37
//Date: 4/9/2024
//Summary: this program will encrypt and decrypt a given file depending on the typeByte

using System;
using System.Collections.Generic;
using System.IO;

namespace lab3{

////////////////////////////////////////////////////////////
//main
class BitchAss{
    static void Main( string[] args ){

        //checking the args
        if( args.Length != 2 ){
            Console.Write( "didnt input 2 units" );
            Environment.Exit( 1 );
        }

        //these are the first five bytes (type byte)
        string inputFile = args[0];
        //these are the rest of the inputs to encrypt and decrpt
        string outputFile = args[1];

        //list for all of the values
        List<byte> values = new List<byte>();

        //reads the bytes of the input
        values = File.ReadAllBytes( inputFile ).ToList();

        //temp list to pass in the current five bytes
        List<List<byte>> tempy = new List<List<byte>>();

        for( int i = 0; i < values.Count; i += 5 ){
            //five bytes at a time
            List<byte> temp = values.Skip( i ).Take( 5 ).ToList();
            tempy.Add( temp );
        }

        List<classContainer> containers = new List<classContainer>();

        //pulls out each list of bytes in every list of list of bytes
        foreach( List<byte> bitchass in tempy ){
            //5 byte list to add to container
            containers.Add( new classContainer( bitchass ) );
        }

        foreach( classContainer container in containers ){
            //cast var contanier to a classContainer
            container.Decode();
        }

        //bc comparison interface == overwriten, it should know how to sort them automatically
        containers.Sort();
        
        using( StreamWriter File = new StreamWriter( outputFile ) ){
            foreach( classContainer container in containers ){
                //has to be " bc string maybe??????
                File.Write( container.Val + "\n" );
            }
        }
    }
}}
