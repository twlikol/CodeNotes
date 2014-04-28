using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Common
{
    public class VsUtil
    {
        public static InterfaceType GetService<InterfaceType, ServiceType>(IServiceProvider serviceProvider)
            where InterfaceType : class
            where ServiceType : class
        {
            InterfaceType result = default(InterfaceType);
            try
            {
                if (serviceProvider != null)
                {
                    result = (serviceProvider.GetService(typeof(ServiceType)) as InterfaceType);
                }
            }
            catch
            {
            }
            return result;
        }

        public static Font FontFromUIDLGLOGFONT(UIDLGLOGFONT logFont)
        {
            char[] array = new char[logFont.lfFaceName.Length];
            int num = 0;
            ushort[] lfFaceName = logFont.lfFaceName;
            for (int i = 0; i < lfFaceName.Length; i++)
            {
                ushort num2 = lfFaceName[i];
                array[num++] = (char)num2;
            }
            string familyName = new string(array);
            float emSize = (float)(-(float)logFont.lfHeight);
            FontStyle fontStyle = FontStyle.Regular;
            if (logFont.lfItalic > 0)
            {
                fontStyle |= FontStyle.Italic;
            }
            if (logFont.lfUnderline > 0)
            {
                fontStyle |= FontStyle.Underline;
            }
            if (logFont.lfStrikeOut > 0)
            {
                fontStyle |= FontStyle.Strikeout;
            }
            if (logFont.lfWeight > 400)
            {
                fontStyle |= FontStyle.Bold;
            }
            GraphicsUnit unit = GraphicsUnit.Pixel;
            byte lfCharSet = logFont.lfCharSet;
            return new Font(familyName, emSize, fontStyle, unit, lfCharSet);
        }
    }
}
