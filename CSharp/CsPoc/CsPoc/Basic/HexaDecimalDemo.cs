using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class HexaDecimalDemo
    {
        public void Execute()
        {
            //StringToHexaFoo();
            //HexaToStringFoo();
            //HexaToIntFoo();
            //HexaToFloatFoo();
            ByteToHexaFoo();
        }

        private void StringToHexaFoo()
        {
            string input = "Hello World!";
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                string hexOutput = String.Format("{0:X}", value);
                Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
            } 
        }

        private void HexaToStringFoo()
        {
            string hexValues = "48 65 6C 6C 6F 20 57 6F 72 6C 64 21";
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (String hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer. 
                int value = Convert.ToInt32(hex, 16);
                // Get the character corresponding to the integral value. 
                string stringValue = Char.ConvertFromUtf32(value);
                char charValue = (char)value;
                Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}",
                hex, value, stringValue, charValue);
            } 
        }

        private void HexaToIntFoo()
        {
            string hexString = "8E2";
            int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(num); 
        }

        private void HexaToFloatFoo()
        {
            string hexString = "43480170";
            uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);
            Console.WriteLine("float convert = {0}", f); 
        }

        private void ByteToHexaFoo()
        {
            byte[] vals = { 0x01, 0xAA, 0xB1, 0xDC, 0x10, 0xDD };
            string str = BitConverter.ToString(vals);
            Console.WriteLine(str);
            str = BitConverter.ToString(vals).Replace("-", "");
            Console.WriteLine(str); 
        }
    }
}
