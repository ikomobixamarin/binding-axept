using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using EU.Axeptio.Sdk;



namespace Test.Axeptio.Android
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity, EU.Axeptio.Sdk.Axeptio.ICompletionHandler
    {
        private EU.Axeptio.Sdk.Axeptio axeptioInstance;

        public void OnCompleted(EU.Axeptio.Sdk.Axeptio.Error error)
        {
            System.Diagnostics.Debug.WriteLine(error?.ToString());

            if(error == null)
            {
                var view = this.FindViewById(Resource.Id.main_linear);
                this.axeptioInstance.ShowConsentView(view, this);
               
            }
        }




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }


        protected override void OnStart()
        {
            base.OnStart();

           this.axeptioInstance = AxeptioKt.GetAxeptio(this);
           this.axeptioInstance.Initialize("<ID>", "<VERSION>", this);

           
        }


    }
}
