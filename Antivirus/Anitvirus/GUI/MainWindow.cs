using Gtk;
using System;
using Antivirus.DataSourceAccess;
using Antivirus.Scanner.Service;
using Cairo;
using DataSourceAccess;
using Signature = DataSourceAccess.Signature;

namespace Antivirus.GUI
{
    public class MainWindow : IDisposable
    {
        [Builder.Object] private Window Window;
        [Builder.Object] private Button SearchBtn;
        [Builder.Object] private Button AddSignatureBtn;
        [Builder.Object] private Switch LogSwch;
        [Builder.Object] private Entry PathEntry;    
        [Builder.Object] private TextView SignatureEntry;
        
        private bool disposed = false;
        private bool log = false;
        private Builder GuiBuilder;

        private ISignatureRepository _signatureRepository;
        private IScannerService _scannerService;

        public MainWindow(ISignatureRepository signatureRepository, IScannerService scannerService)
        {
            _signatureRepository = signatureRepository;
            _scannerService = scannerService;
            
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("GladeWindow/MainWindow.glade");
                GuiBuilder.Autoconnect(this);
                Window.Visible = true;
            }
        }
        
        private void ClickedCloseButton(object sender, EventArgs a) => Application.Quit();
        
        private void ClickedAboutButton(object sender, EventArgs a) => new AboutWindow().Show();
        
        private void ClickedLogButton(object sender, ButtonPressEventArgs a) => log = !log;

        private void ClickedSearchButton(object sender, EventArgs a)
        {
            var result = _scannerService.Scan(PathEntry.Text);
            if (LogSwch.State)
            {
                new LogWindow(result).Show();
            }
            
        }
        
        private void ClickedAddButton(object sender, EventArgs a)
        {
            var signature = SignatureEntry.Buffer.Text.Split('=');

            _signatureRepository.Add(new Signature()
            {
                ActualSignature = signature[1],
                SignatureName = signature[0]
            });
            
            SignatureEntry.Buffer.Text = string.Empty;
        }
            
        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    Window.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Window.Visible = false;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Show() => Window.Visible = true;
        public void Close() => Dispose();
    }
}