using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HiCSUIHelper
{
    /// <summary>
    /// Label鼠标事件代码(主要用于颜色显示)
    /// </summary>
    public class LabelMouseProxy
    {
        /// <summary>
        /// 设置鼠标事件
        /// </summary>
        /// <param name="label"></param>
        public void SetEvent(Label label)
        {
            if (label == null)
            {
                return;
            }

            //添加鼠标事件响应事件
            if (NormalColor != null)
            {
                label.MouseUp += (object sender, MouseEventArgs e) =>
                {
                    SetButtonColor(sender, e, NormalColor);
                };
                label.MouseLeave += (object sender, EventArgs e) =>
                {
                    SetButtonColor(sender, e, NormalColor);
                };

                label.Paint += (object sender, PaintEventArgs e) =>
                {
                    Label lb = sender as Label;
                    if (lb == null)
                    {
                        return;
                    }
                    ButtonPaint(lb, e.Graphics, label.ForeColor, NormalColor); //绘画界面
                };
            }

            if (PressedColor != null)
            {
                label.MouseDown += (object sender, MouseEventArgs e) =>
                {
                    SetButtonColor(sender, e, PressedColor);
                }; 
            }

            if (HoverColor != null)
            {
                label.MouseHover += (object sender, EventArgs e) =>
                {
                    SetButtonColor(sender, e, HoverColor);
                }; 
            }
        }

        /// <summary>
        /// 鼠标激活时的颜色的属性
        /// </summary>
        public Color HoverColor { set; get; }   

        /// <summary>
        /// 正常状态的颜色的属性
        /// </summary>
        public Color NormalColor { set; get; }

        /// <summary>
        /// 鼠标按下时的颜色的属性
        /// </summary>
        public Color PressedColor { set; get; }

        private void SetButtonColor(object o, EventArgs e, Color color)
        {
            Label label = o as Label;
            if (label == null)
            {
                return;
            }

            //这里绘画常规状态的控件界面
            Graphics graphic = label.CreateGraphics(); //创建绘图对象
            ButtonPaint(label, graphic, label.ForeColor, color); //绘画界面
            graphic.Dispose(); //及时释放对象资源
        }

        private void ButtonPaint(Label label, Graphics graphic, Color foreColor, Color backgroundColor)
        {
            graphic.Clear(label.BackColor);  //以背景色清除图象
            //Color lightColor, darkColor;    //定义高亮和暗部分的颜色
            StringFormat textFormat = new StringFormat(); //用于设置文字格式
            LinearGradientBrush brush; //定义渐变笔刷
            Rectangle rect = new Rectangle(0, 0, label.Width - 1, label.Height - 1); //获取矩型区域
            //lightColor = Color.FromArgb(0, backgroundColor);  //获取高亮颜色
            //darkColor = Color.FromArgb(255, backgroundColor); //获取暗颜色
            //生成渐变笔刷实例
            //brush = new LinearGradientBrush(rect, lightColor, darkColor, LinearGradientMode.BackwardDiagonal);
            brush = new LinearGradientBrush(rect, backgroundColor, backgroundColor, LinearGradientMode.BackwardDiagonal);
            graphic.FillRectangle(brush, rect); //使用渐变画笔刷填充 
            graphic.DrawRectangle(new Pen(foreColor), rect); //使用前景色画边框
            textFormat.Alignment = StringAlignment.Center; //设置文字垂直对齐方式          
            textFormat.LineAlignment = StringAlignment.Center; //设置文字水平对齐方式
            //绘画控件显示的正文
            graphic.DrawString(label.Text, label.Font, new SolidBrush(foreColor), rect, textFormat);
        }
    }
}
