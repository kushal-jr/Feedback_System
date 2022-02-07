using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Admin_Graph1 : System.Web.UI.Page
{
    void DrawBarGraph(string strTitle, ArrayList aX, ArrayList aY)
    {
        try
        {
            const int iColWidth = 60;
            const int iColSpace = 35;
            const int iMaxHeight = 400;
            const int iHeightSpace = 25;
            const int iXLegendSpace = 30;
            const int iTitleSpace = 50;
            int iMaxWidth = (iColWidth + iColSpace) * aX.Count + iColSpace;
            int iMaxColHeight = 0;
            int iTotalHeight = iMaxHeight + iXLegendSpace + iTitleSpace;

            Bitmap objBitmap = new Bitmap(iMaxWidth + 30, iTotalHeight);
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            // find the maximum value
            for (int i = 0; i < aY.Count; i++)
            {
                if (Convert.ToInt32(aY[i]) > iMaxColHeight)
                    iMaxColHeight = Convert.ToInt32(aY[i]);
            }
            int iBarX = iColSpace;
            float iCurrentHeight = 0;
            SolidBrush objBrush = new SolidBrush(Color.FromArgb(255, 10, 80));
            SolidBrush objBrush1 = new SolidBrush(Color.FromArgb(10, 100, 200));

            Font fontLegend = new Font("Comic Sans MS", 11);
            Font fontValues = new Font("Comic Sans MS", 8);
            Font fontTitle = new Font("Comic Sans MS", 24);

            //// loop through and draw each bar
            int iLoop;
            if (iMaxColHeight != 0)
            {
                for (iLoop = 0; iLoop <= aX.Count - 1; iLoop++)
                {
                    int m = Convert.ToInt32(aY[iLoop]);
                    int n = (iMaxHeight - iHeightSpace) * m;
                    float mn = n / iMaxColHeight;
                    iCurrentHeight = mn;
                    int curentHeight = Convert.ToInt32(iCurrentHeight);
                    objGraphics.FillRectangle(objBrush1, iBarX, (iMaxHeight - iCurrentHeight), iColWidth, iCurrentHeight);
                    objGraphics.DrawString(aX[iLoop].ToString(), fontLegend, objBrush, iBarX, iMaxHeight);
                    objGraphics.DrawString(aY[iLoop].ToString(), fontValues, objBrush, iBarX, iMaxHeight - iCurrentHeight - 15);
                    iBarX += (iColSpace + iColWidth);

                }
            }
            objGraphics.DrawString(strTitle, fontTitle, objBrush, (iMaxWidth / 2) - strTitle.Length * 6, iMaxHeight + iXLegendSpace);
            Response.ContentType = "image/gif";
            //objBitmap.Save("./graph.gif", ImageFormat.Gif);
            //objBitmap.Save(
            objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
            objGraphics.Dispose();
            objBitmap.Dispose();

        }
        catch (Exception)
        {


        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int exval = Convert.ToInt32(Session["exval"]);
        int vgval = Convert.ToInt32(Session["vgval"]);
        int gval = Convert.ToInt32(Session["gval"]);
        int sval = Convert.ToInt32(Session["sval"]);
        int nsval = Convert.ToInt32(Session["nsval"]);
        ArrayList aTitles = new ArrayList();
        aTitles.Add("Excellent");
        aTitles.Add("VeryGood");
        aTitles.Add("Good");
        aTitles.Add("Satisfactory");
        aTitles.Add("NotSatisfactory");
        ArrayList aValues = new ArrayList();
        aValues.Add(exval);
        aValues.Add(vgval);
        aValues.Add(gval);
        aValues.Add(sval);
        aValues.Add(nsval);
        DrawBarGraph("Feed Back!", aTitles, aValues);
    }
}
