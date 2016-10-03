<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:csfun="urn:csharp-functions" exclude-result-prefixes="msxsl">
    <msxsl:script implements-prefix="csfun" language="C#">
        <![CDATA[        
        public bool CheckDate(string target)
        {
            DateTime dtTarget;

            if (DateTime.TryParse(target, out dtTarget))
            {
                DateTime dtMinDate = new DateTime(1900, 1, 1);
                DateTime dtMaxDate = new DateTime(2079, 6, 1);

                if ((dtTarget - dtMinDate).Days > 0 && (dtTarget - dtMaxDate).Days < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckInt(string target)
        {
            int tmpInt;

            if (int.TryParse(target, out tmpInt))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool CheckLong(string target)
        {
            long tmpLong;

            if (long.TryParse(target, out tmpLong))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckDouble(string target)
        {
            double tmpDouble;
            if (double.TryParse(target, out tmpDouble))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckDecimal(string target)
        {
            decimal tmpDecimal;
            if (decimal.TryParse(target, out tmpDecimal))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        public string Trim(string target)
        {
            if (target == null)
            {
                return null;
            }
            else 
            {
                return target.Trim();
            }

        }

        

        public string TrimSymbol(string target, string symbol)
        {
            if (target == null || symbol == null)
            {
                return null;
            }
            else 
            {
                return target.Replace(symbol, string.Empty);
            }
        }
        ]]>

    </msxsl:script>
</xsl:stylesheet>