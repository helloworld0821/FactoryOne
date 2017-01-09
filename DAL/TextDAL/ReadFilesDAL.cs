using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactorsAnalysis.DAL
{

    class ReadFilesDAL
    {
        public static List<decimal> lstPressure = new List<decimal>();
        public static List<decimal> lstSoil = new List<decimal>();
        public static List<decimal> lstFipoil = new List<decimal>();
        //public static List<decimal> lstKX = new List<decimal>();
        //public static List<decimal> lstDZ = new List<decimal>();
        //public static List<decimal> lstDCXS = new List<decimal>();
        //public static List<decimal> lstPORO = new List<decimal>();
        public static void ReadFiles(string path)
        {
            lstPressure.Clear();
            lstSoil.Clear();
            lstFipoil.Clear();
            bool isPressure = false, isSoil = false, isFipoil = false;
            //List<decimal> lstSoil = new List<decimal>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string strReadLine = sr.ReadLine();

            while (strReadLine != null)
            {
                strReadLine = strReadLine.Trim();
                if (strReadLine.Equals("SOIL"))
                {
                    strReadLine = sr.ReadLine();
                    isSoil = true;
                }
                if (strReadLine.Equals("PRESSURE"))
                {
                    strReadLine = sr.ReadLine();
                    isPressure = true;
                }
                else if (strReadLine.Equals("FIPOIL"))
                {
                    strReadLine = sr.ReadLine();
                    isFipoil = true;
                }
                if (isSoil)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isSoil = false;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstSoil.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }
                }
                if (isFipoil)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isFipoil = false;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstFipoil.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }
                }


                if (isPressure)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isPressure = false;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstPressure.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }

                }
                strReadLine = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }
        /*
        public static void ReadPermX()
        {
            bool isPermx = false;

            FileStream fs = new FileStream("KX", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string strReadLine = sr.ReadLine();
            while (strReadLine != null)
            {
                strReadLine = strReadLine.Trim();
                if (strReadLine.Equals("PERMX"))
                {
                    strReadLine = sr.ReadLine();
                    isPermx = true;
                }
                if (isPermx)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isPermx = false;
                        break;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstKX.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }
                }
                strReadLine = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void ReadDZ()
        {
            bool isPermx = false;

            FileStream fs = new FileStream("DZ", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string strReadLine = sr.ReadLine();
            while (strReadLine != null)
            {
                strReadLine = strReadLine.Trim();
                if (strReadLine.Equals("DZ"))
                {
                    strReadLine = sr.ReadLine();
                    isPermx = true;
                }
                if (isPermx)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isPermx = false;
                        break;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstDZ.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }
                }
                strReadLine = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void ReadPORO()
        {
            bool isPORO = false;

            FileStream fs = new FileStream("poro.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string strReadLine = sr.ReadLine();
            while (strReadLine != null)
            {
                strReadLine = strReadLine.Trim();
                if (strReadLine.Equals("PORO"))
                {
                    strReadLine = sr.ReadLine();
                    isPORO = true;
                }
                if (isPORO)
                {
                    strReadLine = strReadLine.Trim();
                    if (strReadLine.Equals("/"))
                    {
                        isPORO = false;
                        break;
                    }
                    else
                    {
                        string[] strArray = Regex.Split(strReadLine, @"\s+");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            lstPORO.Add(Convert.ToDecimal(Convert.ToDouble(strArray[i])));
                        }
                    }
                }
                strReadLine = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void CalcDCXS()
        {            
            for (int i = 0; i < lstDZ.Count(); i++)
            {
                lstDCXS.Add(lstDZ[i] * lstKX[i]);
            }
        }
        */
    }
}
