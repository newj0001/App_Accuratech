using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.AIDC.CrossPlatform.BarcodeReader.dll
{
    public class BarcodeReadEventArgs : System.EventArgs
    {
        public string SymbologyIdentifier { get; set; }
        public bool IsNoread { get; set; }
        public bool IsNoParse { get; set; }
        public string RawBarcode { get; set; }
        public Dictionary<string, string> BarcodeData { get; set; }
        public string GetElement(string ai)
        {
            if (null == BarcodeData) return String.Empty;
            return BarcodeData.ContainsKey(ai) ? BarcodeData[ai] : String.Empty;
        }
    }
}
