using Foundation;
using System;
using UIKit;
using NativeLibrary;

namespace Test.Axeptio.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var a = new Action<NSError>((e) => { System.Diagnostics.Debug.WriteLine("{e}"); });

            // Perform any additional setup after loading the view, typically from a nib.
            try
            {
                NativeLibrary.Axeptio.InitializeWithClientId("<ID>", "<VERSION>", a);
            }
            catch(Exception e)
            {

            }
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
