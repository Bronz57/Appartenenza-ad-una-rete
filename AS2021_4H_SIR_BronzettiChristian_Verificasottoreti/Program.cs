using System;
using System.Collections.Generic;

namespace AS2021_4H_SIR_BronzettiChristian_Verificasottoreti
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


    public static class SottoRete
    {
        //fare AND logico tra SM indirizzo ip da controllare, conventenoli prima in ip,
        //se appartiene deve ritornare il l'indirizzo network

        /// <summary>
        /// sono semparati da un .
        /// </summary>
        /// <param name="networkIp"></param>
        /// <param name="subnetMask"></param>
        /// <param name="ipDaAnalizzare"></param>
        /// <returns></returns>
        /// true se appartiene, false se no
        static public bool VerificaAppartenenza(string networkIp, string subnetMask, string ipDaAnalizzare)
        {
            List<string> retVal = ConvertiInDecimale
                                                    (
                                                        ProdottoLogicoAnd
                                                        (
                                                            ConvertitoreBinario(ipDaAnalizzare),
                                                            ConvertitoreBinario(subnetMask)
                                                        )
                                                    );

            List<string> ipNetwork = new List<string>(networkIp.Split('.'));

            for (int i = 0; i < retVal.Count; i++)
                if (!retVal[i].Equals(ipNetwork[i]))
                    return false;

            return true;
        }


        static List<string> ProdottoLogicoAnd(List<string> str1, List<string> str2)
        { 
            //l'and funziona che se sono entrambi 1 è 1 altrimenti 0
            // A B | AB
            // 0 0 | 0
            // 0 1 | 0
            // 1 0 | 0
            // 1 1 | 1

            string retVal = "";
            List<string> final = new List<string>();

            //controllo bit a bit
            for (int i = 0, j =0; i < str1.Count && j < str2.Count; i++,j++)
            {
                for (int m = 0, n = 0; m < str1[i].Length && n < str2[i].Length ; m++, n++)
                {
                    if (str1[i][m].Equals('1') && str2[j][n].Equals('1'))
                        retVal += '1';
                    else
                        retVal += '0';
                }
                   
                final.Add(retVal);
                retVal = "";
            }

            return final;
        }
        static List<string> ConvertitoreBinario(string daConvertireInBinario)
        {
            List<string> retval = DividiByte(daConvertireInBinario); //list senza . di stringhe
            List<int> valoriDaConvertire = new List<int>(); //list di int

            foreach (string s in retval)
                valoriDaConvertire.Add(Convert.ToInt32(s));

            string ris = "";
            retval.Clear();

            for (int i = 0; i < valoriDaConvertire.Count; i++)
            {
                if (valoriDaConvertire[i] == 0)
                    ris = "0";
                else
                    while (valoriDaConvertire[i] != 0)
                    {
                        int resto = valoriDaConvertire[i] % 2; //salvo resto
                        valoriDaConvertire[i] = (valoriDaConvertire[i] - resto) / 2;
                        ris = resto.ToString() + ris;
                    }

                retval.Add(ris);
                ris = "";
            }

            return retval;
        }

        static List<string> DividiByte(string retVal)
        {
            // list dove contengo ogni numero separato da virgola
            List<string> numeriSenzaPunto = new List<string>(retVal.Split('.'));
            
            return numeriSenzaPunto;
        }
                   
        static List<string> ConvertiInDecimale(List<string> daConvertire)
        {
            List<string> convertiti = new List<string>();
            foreach (string s in daConvertire)
                convertiti.Add(Convert.ToInt32(s, 2).ToString());

            return convertiti;
        }
    }
}
