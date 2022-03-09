using System.Windows.Forms;

namespace UNetBrowser
{
    public partial class NetMethodControl : UserControl
    {
        public NetMethod NetMethod;
        public NetMethodControl()
        {
            InitializeComponent();
        }

        public NetMethodControl(NetMethod method)
        {
            InitializeComponent();
            NetMethod = method;
            lblHandler.Text = method.Handler;
            lblSendHandle.Text = method.SendHandle;
            lblSentBy.Text = method.SentBy;
            lblType.Text = method.DeclaringType;

            lblParams.Text = method.Parameters;

            if (method.LegacyName == null)
            {
                Height -= lblLegacy.Height;
                lblLegacy.Visible = false;
            }
            else
            {
                lblLegacy.Text = method.LegacyName;
            }
        }
    }
}