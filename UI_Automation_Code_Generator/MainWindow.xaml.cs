using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interop.UIAutomationCore;

namespace UI_Automation_Code_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Refresh_Tree_Click(object sender, RoutedEventArgs e)
        {
            this.AutomationTree_TargetUpdated(sender, null);
        }

        private void AutomationTree_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //IUIAutomationCondition uIAutomationCondition = new IUIAutomationCondition();
            CUIAutomation8 cUIAutomation8 = new CUIAutomation8();
            IUIAutomationElementArray rootChildrens = cUIAutomation8.GetRootElement().FindAll(TreeScope.TreeScope_Children, cUIAutomation8.CreateTrueCondition());
            TreeViewItem tree = new TreeViewItem();
            tree.Header = cUIAutomation8.GetRootElement().GetCurrentPropertyValue(30005);
          //  IUIAutomationTreeWalker uIAutomationTreeWalker;
           // uIAutomationTreeWalker.
            for(int i = 0; i <rootChildrens.Length; i++)
            {
                IUIAutomationElement children = rootChildrens.GetElement(i);
                tree.Items.Add(String.Format("{0}  {1}", children.GetCurrentPropertyValue(30005), children.CurrentLocalizedControlType));
            }
            automationTree.Items.Add(tree);
            //MessageBox.Show(rootElement.GetCurrentPropertyValue(30012));

        }
    }
}
