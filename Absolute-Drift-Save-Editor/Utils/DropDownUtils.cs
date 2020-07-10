using System.Windows.Forms;

namespace Absolute_Drift_Save_Editor.Utils
{
    public static class DropDownUtils
    {
        public static int AutoDropDownWidth(this ToolStripComboBox comboBox)
        {
            int maxWidth = 1;
            int temp = 1;
            int vertScrollBarWidth = (comboBox.Items.Count > comboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            foreach (string obj in comboBox.Items)
            {
                temp = TextRenderer.MeasureText(obj, comboBox.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }

            }
            return maxWidth + vertScrollBarWidth;
        }
    }
}
