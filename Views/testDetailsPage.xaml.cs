using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.Devices.PointOfService;
using System.Collections.Generic;
using Phasmaphobia_Editor.Core.Services;
using Phasmaphobia_Editor.ViewModels;

namespace Phasmaphobia_Editor.Views
{
    public sealed partial class testDetailsPage : Page
    {
        public testDetailsViewModel ViewModel { get; } = new testDetailsViewModel();



        public testDetailsPage()
        {
            InitializeComponent();
            Loaded += testDetailsPage_Loaded;

            spiritBox.Indeterminate += sb_ind;
            emf5.Indeterminate += em5_ind;
            dots.Indeterminate += dots_ind;
            ultraViolet.Indeterminate += uv_ind;
            freezing.Indeterminate += frz_ind;
            ghostOrbs.Indeterminate += orbs_ind;
            writing.Indeterminate += writing_ind;

        }

        string t = "true";
        string f = "false";
        string n = "null";

        private void writing_ind(object sender, RoutedEventArgs e)
        {
            writingstate = n;
            current--;
            getCheckedAsync();
        }

        private void orbs_ind(object sender, RoutedEventArgs e)
        {

            ghostorbsstate = n; current--; getCheckedAsync();
        }

        private void frz_ind(object sender, RoutedEventArgs e)
        {
            freezingstate = n; current--; getCheckedAsync();
        }

        private void uv_ind(object sender, RoutedEventArgs e)
        {
            ultravioletstate = n; current--; getCheckedAsync();
        }

        private void dots_ind(object sender, RoutedEventArgs e)
        {
            dotsstate = n; current--; getCheckedAsync();
        }

        private void em5_ind(object sender, RoutedEventArgs e)
        {
            em5state = n; current--; getCheckedAsync();
        }

        string em5state = "false";
        string dotsstate = "false";
        string ultravioletstate = "false";
        string freezingstate = "false";
        string ghostorbsstate = "false";
        string writingstate = "false";
        string spiritboxstate = "false";
        int current = 0;


        private void sb_ind(object sender, RoutedEventArgs e)
        {
            spiritboxstate = n; current--; getCheckedAsync();
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public async void testDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            Debug.WriteLine("HOOP " + writing.IsThreeState);
        }

        private void ListDetailsViewControl_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {

        }
        private void spiritBox_Click(object sender, RoutedEventArgs e)
        {

            if (spiritBox.IsChecked == true)
            {
                spiritboxstate = t;
                current++; getCheckedAsync();
            }
            else if (spiritBox.IsChecked == false)
            {
                reset();
                spiritboxstate = f; getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }

        private void writing_Click(object sender, RoutedEventArgs e)
        {

            if (writing.IsChecked == true)
            {
                writingstate = t;
                current++;
                getCheckedAsync();
            }
            else if (writing.IsChecked == false)
            {
                reset();
                writingstate = f; getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }

        private void ghostOrbs_Click(object sender, RoutedEventArgs e)
        {

            if (ghostOrbs.IsChecked == true)
            {
                ghostorbsstate = t;
                current++;
                getCheckedAsync();
            }
            else if (ghostOrbs.IsChecked == false)
            {
                reset();
                ghostorbsstate = f;getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }



        public async Task twoCheckedAsync()
        {
            var data = await SampleDataService.GetListDetailsDataAsync();

            if (em5state == t && dotsstate == t)
            {
                writing.IsEnabled = false;
                foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("EMF 5") && tog.Contains("DOTs"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (em5state == "true" && ultravioletstate == "true")
            {
                spiritBox.IsEnabled = false;
                foreach (var item in data)
                {
                    string tog;

                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("EMF 5") && tog.Contains("Ultraviolet"))
                    {

                        PutInAsync(item.Company);
                    }
                }
            }
            else if (em5state == "true" && freezingstate == "true")
            {
                ghostOrbs.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;

                    if (tog.Contains("EMF 5") && tog.Contains("Freezing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (em5state == "true" && ghostorbsstate == "true")
            {
                freezing.IsEnabled = false; writing.IsEnabled = false; spiritBox.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("EMF 5") && tog.Contains("Ghost Orbs"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (em5state == "true" && writingstate == "true")
            {
                dots.IsEnabled = false; ghostOrbs.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("EMF 5") && tog.Contains("Writing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (em5state == "true" && spiritboxstate == "true")
            {
                ghostOrbs.IsEnabled = false; ultraViolet.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("EMF 5") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }

            else if (dotsstate == "true" && ultravioletstate == "true")
            {
                freezing.IsEnabled = false; writing.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("DOTs") && tog.Contains("Ultraviolet"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (dotsstate == "true" && freezingstate == "true")
            {
                ultraViolet.IsEnabled = false; writing.IsEnabled = false; spiritBox.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("DOTs") && tog.Contains("Freezing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (dotsstate == "true" && ghostorbsstate == "true")
            {
                foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("DOTs") && tog.Contains("Ghost Orbs"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (dotsstate == "true" && writingstate == "true")
            {
                emf5.IsEnabled = false; ultraViolet.IsEnabled = false; freezing.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("DOTs") && tog.Contains("Writing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (dotsstate == "true" && spiritboxstate == "true")
            {
                freezing.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("DOTs") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }

            else if (ultravioletstate == "true" && freezingstate == "true")
            {
                dots.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ultraviolet") && tog.Contains("Freezing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (ultravioletstate == "true" && ghostorbsstate == "true")
            {
                writing.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ultraviolet") && tog.Contains("Ghost Orbs"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (ultravioletstate == "true" && writingstate == "true")
            {
                ghostOrbs.IsEnabled = false; dots.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ultraviolet") && tog.Contains("Writing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (ultravioletstate == "true" && spiritboxstate == "true")
            {
                emf5.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ultraviolet") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }

            else if (freezingstate == "true" && ghostorbsstate == "true")
            {
                emf5.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Freezing") && tog.Contains("Ghost Orbs"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (freezingstate == "true" && writingstate == "true")
            {
                dots.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Freezing") && tog.Contains("Writing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (freezingstate == "true" && spiritboxstate == "true")
            {
                dots.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Freezing") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }

            else if (ghostorbsstate == "true" && writingstate == "true")
            {
                emf5.IsEnabled = false; ultraViolet.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ghost Orbs") && tog.Contains("Writing"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
            else if (ghostorbsstate == "true" && spiritboxstate == "true")
            {
                ultraViolet.IsEnabled = false; emf5.IsEnabled = false; foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Ghost Orbs") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }

            else if (writingstate == "true" && spiritboxstate == "true")
            {
                foreach (var item in data)
                {
                    string tog;
                    tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                    if (tog.Contains("Writing") && tog.Contains("Spirit Box"))
                    {
                        PutInAsync(item.Company);
                    }
                }
            }
        }
        string evidence2;
        public async Task threeCheckedAsync()
        {
            evidence2 = "";
            SampleItems.Clear();

            var data = await SampleDataService.GetListDetailsDataAsync();

            if (emf5.IsChecked == true)
            {
                evidence2 = evidence2 + "EMF 5=";
            }
            if (dots.IsChecked == true)
            {
                evidence2 = evidence2 + "DOTs=";
            }
            if (ultraViolet.IsChecked == true)
            {
                evidence2 = evidence2 + "Ultraviolet=";
            }
            if (freezing.IsChecked == true)
            {
                evidence2 = evidence2 + "Freezing=";
            }
            if (ghostOrbs.IsChecked == true)
            {
                evidence2 = evidence2 + "Ghost Orbs=";
            }
            if (writing.IsChecked == true)
            {
                evidence2 = evidence2 + "Writing=";
            }
            if (spiritBox.IsChecked == true)
            {
                evidence2 = evidence2 + "Spirit Box=";
            }
            string[] evidence = evidence2.Split("=");

            foreach (var item in data)
            {
                string tog;
                tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                Debug.WriteLine(" ");
                Debug.WriteLine(item.Company + " " + tog);
                Debug.WriteLine("Evidence " + evidence[0] + " " + evidence[1] + " " + evidence[2] + " ");
                if (tog.Contains(evidence[0]) && tog.Contains(evidence[1]) && tog.Contains(evidence[2]))
                {
                    await PutInAsync(item.Company);
                }
            }

            //if (em5state == t && spiritboxstate == t && writingstate == t)
            //{
            //    foreach(var item in data)
            //    {
            //        if(item.Company == "SPIRIT")
            //        {
            //            SampleItems.Add(item);
            //        }
            //    }
            //}
            //if (em5state == t && spiritboxstate == t && dotsstate == t)
            //{
            //    foreach (var item in data)
            //    {
            //        if (item.Company == "WRAITH")
            //        {
            //            SampleItems.Add(item);
            //        }
            //    }
            //}
            //if (em5state == t && spiritboxstate == t && dotsstate == t)
            //{
            //    foreach (var item in data)
            //    {
            //        if (item.Company == "")
            //        {
            //            SampleItems.Add(item);
            //        }
            //    }
            //}








            if (emf5.IsChecked == false)
            {
                emf5.IsEnabled = false;
            }
            if (dots.IsChecked == false)
            {
                dots.IsEnabled = false;
            }
            if (ultraViolet.IsChecked == false)
            {
                ultraViolet.IsEnabled = false;
            }
            if (freezing.IsChecked == false)
            {
                freezing.IsEnabled = false;
            }
            if (ghostOrbs.IsChecked == false)
            {
                ghostOrbs.IsEnabled = false;
            }
            if (writing.IsChecked == false)
            {
                writing.IsEnabled = false;
            }
            if (spiritBox.IsChecked == false)
            {
                spiritBox.IsEnabled = false;
            }
        }

        public async Task getCheckedAsync()
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetListDetailsDataAsync();
            Debug.WriteLine("Checked at" + current.ToString());
            switch (current)
            {
                case 0:
                    foreach (var item in data)
                    {
                        await PutInAsync(item.Company);
                    }
                    break;
                case 1:
                    if (em5state == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("EMF 5"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (dotsstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("DOTs"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (ultravioletstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("Ultraviolet"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (freezingstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("Freezing"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (ghostorbsstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("Ghost Orbs"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (writingstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("Writing"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }
                    else if (spiritboxstate == t)
                    {
                        foreach (var item in data)
                        {
                            string tog;
                            tog = item.Evidence1 + " " + item.Evidence2 + " " + item.Evidence3;
                            if (tog.Contains("Spirit Box"))
                            {
                                await PutInAsync(item.Company);
                            }
                        }
                    }

                    if (emf5.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (dots.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (ultraViolet.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (freezing.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (ghostOrbs.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (writing.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    if (spiritBox.IsEnabled == false)
                    {
                        emf5.IsEnabled = true;
                        dots.IsEnabled = true;
                        ultraViolet.IsEnabled = true;
                        freezing.IsEnabled = true;
                        ghostOrbs.IsEnabled = true;
                        writing.IsEnabled = true;
                        spiritBox.IsEnabled = true;
                    }
                    break;
                case 2:
                    twoCheckedAsync();
                    Debug.WriteLine("case 2");
                    break;
                case 3:
                    Debug.WriteLine("case3 ");
                    threeCheckedAsync();
                    break;
            }
        }



        public async void threeEvidence()
        {

        }

        string notit;
        string together;
        public async Task PutInAsync(string ghost)
        {
            together = "";
            //  string[] test = notit.Split("=");

            var data = await SampleDataService.GetListDetailsDataAsync();

            foreach (var item in data)
            {
                if (item.Company == ghost)
                {
                    if (em5state == n)
                    {
                        together += "EMF 5 ";
                    }
                    if (dotsstate == n)
                    {
                        together += "DOTs ";
                    }
                    if (ultravioletstate == n)
                    {
                        together += "Ultraviolet ";
                    }
                    if (freezingstate == n)
                    {
                        together += "Freezing ";
                    }
                    if (ghostorbsstate == n)
                    {
                        together += "Ghost Orbs ";
                    }
                    if (writingstate == n)
                    {
                        together += "Writing ";
                    }
                    if (spiritboxstate == n)
                    {
                        together += "Spirit Box ";
                    }

                    if (!together.Contains(item.Evidence1) && !together.Contains(item.Evidence2) && !together.Contains(item.Evidence3))
                    {
                        Debug.Write("yeee");
                        SampleItems.Add(item);
                    }
                }
            }
        }

        public async void Update()
        {

            var data = await SampleDataService.GetListDetailsDataAsync();

            foreach (var item in data)
            {
                await PutInAsync(item.Company);
            }
            try
            {
                ListDetailsViewControl.SelectedIndex = 0;
            }
            catch
            {

            }

        }

        private void freezing_Click(object sender, RoutedEventArgs e)
        {
            if (freezing.IsChecked == true)
            {

                freezingstate = t;
                current++; getCheckedAsync();
            }
            else if (freezing.IsChecked == false)
            {
                reset();
                freezingstate = f;  getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }

        private void ultraViolet_Click(object sender, RoutedEventArgs e)
        {
            if (ultraViolet.IsChecked == true)
            {

                ultravioletstate = t;
                current++; getCheckedAsync();
            }
            else if (ultraViolet.IsChecked == false)
            {
                reset();
                ultravioletstate = f; getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }

        private void dots_Click(object sender, RoutedEventArgs e)
        {
            if (dots.IsChecked == true)
            {

                dotsstate = t; current++; getCheckedAsync();
            }
            else if (dots.IsChecked == false)
            {
                reset();
                dotsstate = f; getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }

        private void reset()
        {
            if (emf5.IsEnabled == false)
            {
                emf5.IsEnabled = true;
            }
            if (dots.IsEnabled == false)
            {
                dots.IsEnabled = true;
            }
            if (ultraViolet.IsEnabled == false)
            {
                ultraViolet.IsEnabled = true;
            }
            if (freezing.IsEnabled == false)
            {
                freezing.IsEnabled = true;
            }
            if (ghostOrbs.IsEnabled == false)
            {
                ghostOrbs.IsEnabled = true;
            }
            if (writing.IsEnabled == false)
            {
                writing.IsEnabled = true;
            }
            if (spiritBox.IsEnabled == false)
            {
                spiritBox.IsEnabled = true;
            }
        }

        private void emf5_Click(object sender, RoutedEventArgs e)
        {
            if (emf5.IsChecked == true)
            {

                em5state = t;
                current++;
                getCheckedAsync();
            }
            else if (emf5.IsChecked == false)
            {
                reset();
                em5state = f;
                getCheckedAsync();
            }
            Debug.WriteLine(current.ToString());
        }
    }
}
