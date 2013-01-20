using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
namespace Utilidad
{
    public class Imagen
    {
        public static byte[] Image2Bytes(Image pImagen)
	    {
		    byte[] mImage = null;
		    try
		    {
			    if (pImagen != null)
			    {
				    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
				    {
					    pImagen.Save(ms, pImagen.RawFormat);
					    mImage = ms.GetBuffer();
					    ms.Close();
				    }
			    }
			    else { mImage = null; }
		    }
		    catch (Exception ex)
		    {
			    throw (ex);
		    }
		    return mImage;
	     }
 
	    public static Image Bytes2Image(byte[] bytes)
	    {
		    if (bytes == null) return null;
		    using (MemoryStream ms = new MemoryStream(bytes))
		    {
			    Bitmap bm = null;
			    try
			    {
				    bm = new Bitmap(ms);
			    }
			    catch (Exception ex)
			    {
				    throw (ex);
			    }
			    return bm;
		    }
	    }
    }
}
