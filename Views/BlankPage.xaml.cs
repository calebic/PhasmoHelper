using System;
using System.Collections.Generic;
using System.Drawing;
using Phasmaphobia_Editor.ViewModels;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Phasmophobia_Save_Editor;
using Windows.UI.Popups;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Windows.Storage;
using Windows.System;
using System.Security.Principal;
using System.CodeDom;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Documents;
using static System.Environment;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Phasmaphobia_Editor.Views
{
    public sealed partial class BlankPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        private static string SavePath;
        private Dictionary<string, SaveGenericProperty> sf;
        // Token: 0x0400000D RID: 13
        private static bool ExperienceSet = false;
        private static Dictionary<string, string> NameLookupTable = new Dictionary<string, string>
        {
            {
                "moneyNumUpDown",
                "PlayersMoney"
            },
            {
                "expNumUpDown",
                "myTotalExp"
            },
            {
                "emfNumUpDown",
                "EMFReaderInventory"
            },
            {
                "flashlightNumUpDown",
                "FlashlightInventory"
            },
            {
                "cameraNumUpDown",
                "CameraInventory"
            },
            {
                "lighterNumUpDown",
                "LighterInventory"
            },
            {
                "candleNumUpDown",
                "CandleInventory"
            },
            {
                "uvFlashlightNumUpDown",
                "UVFlashlightInventory"
            },
            {
                "crucifixNumUpDown",
                "CrucifixInventory"
            },
            {
                "dslrCameraNumUpDown",
                "DSLRCameraInventory"
            },
            {
                "evpRecorderNumUpDown",
                "EVPRecorderInventory"
            },
            {
                "saltNumUpDown",
                "SaltInventory"
            },
            {
                "sageNumUpDown",
                "SageInventory"
            },
            {
                "tripodNumUpDown",
                "TripodInventory"
            },
            {
                "strongFlashlightNumUpDown",
                "StrongFlashlightInventory"
            },
            {
                "motionSensorNumUpDown",
                "MotionSensorInventory"
            },
            {
                "soundSensorNumUpDown",
                "SoundSensorInventory"
            },
            {
                "sanityPillsNumUpDown",
                "SanityPillsInventory"
            },
            {
                "thermometerNumUpDown",
                "ThermometerInventory"
            },
            {
                "ghostWritingBookNumUpDown",
                "GhostWritingBookInventory"
            },
            {
                "dotsProjectorNumUpDown",
                "DOTSProjectorInventory"
            },
            {
                "parabolicMicNumUpDown",
                "ParabolicMicrophoneInventory"
            },
            {
                "glowstickNumUpDown",
                "GlowstickInventory"
            },
            {
                "goProNumUpDown",
                "HeadMountedCameraInventory"
            }
        };

        bool saveOpen;

        public BlankPage()
        {
            InitializeComponent();
           // string text2 = "C://Users/icey7/AppData/LocalLow/Kinetic Games/Phasmophobia/SaveFile.txt";
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        string user;
        public string UserNameStr { get; set; } = WindowsIdentity.GetCurrent().Name;
        string[] final;

        private void getTiers()
        {
            Debug.WriteLine(getvalue("DOTSProjectorTier"));
            dotstier.Value = Convert.ToInt32(getvalue("DOTSProjectorTier"));
            emftier.Value = Convert.ToInt32(getvalue("EMFReaderTier"));
            bookstier.Value = Convert.ToInt32(getvalue("GhostWritingBookTier"));
            spiritboxtier.Value = Convert.ToInt32(getvalue("SpiritBoxTier"));
            thermometerstier.Value = Convert.ToInt32(getvalue("ThermometerTier"));
            uvflashlightstier.Value = Convert.ToInt32(getvalue("UVLightTier"));
            flashlighttier.Value = Convert.ToInt32(getvalue("FlashlightTier"));
            videocamerastier.Value = Convert.ToInt32(getvalue("VideoCameraTier"));
            crucifixstier.Value = Convert.ToInt32(getvalue("CrucifixTier"));
            candlestier.Value = Convert.ToInt32(getvalue("FirelightTier"));
            goprotier.Value = Convert.ToInt32(getvalue("HeadGearTier"));
            lighterstier.Value = Convert.ToInt32(getvalue("IgniterTier"));
            sagetier.Value = Convert.ToInt32(getvalue("RepellentTier"));
            motionsensorstier.Value = Convert.ToInt32(getvalue("MotionSensorTier"));
            micstier.Value = Convert.ToInt32(getvalue("ParabolicMicrophoneTier"));
            camerastier.Value = Convert.ToInt32(getvalue("PhotoCameraTier"));
            tripodstier.Value = Convert.ToInt32(getvalue("TripodTier"));
            soundsensorstier.Value = Convert.ToInt32(getvalue("SoundSensorTier"));
            salttier.Value = Convert.ToInt32(getvalue("SaltTier"));
            sanitypillstier.Value = Convert.ToInt32(getvalue("SanityMedicationTier"));



        }

        private string getvalue(string s)
        {
            try
            {
                return this.sf[s].Value.ToString();
            }catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        private void EnumFields()
        {
            getTiers();
            EMFReader.Text = sf["EMFReaderInventory"].Value.ToString();
            DOTS.Text = sf["DOTSProjectorInventory"].Value.ToString();
            Books.Text = sf["GhostWritingBookInventory"].Value.ToString();
            spiritbox.Text = sf["SpiritBoxInventory"].Value.ToString();
            Thermometers.Text = sf["ThermometerInventory"].Value.ToString();
            UVFlashlights.Text = sf["UVLightInventory"].Value.ToString();
            Flashlights.Text = sf["FlashlightInventory"].Value.ToString();
            videocameras.Text = sf["VideoCameraInventory"].Value.ToString();
            Crucifixs.Text = sf["CrucifixInventory"].Value.ToString();
            Candles.Text = sf["FirelightInventory"].Value.ToString();
            GoPro.Text = sf["HeadGearInventory"].Value.ToString();
            Lighters.Text = sf["IgniterInventory"].Value.ToString();
            Sage.Text = sf["RepellentInventory"].Value.ToString();
            MotionSensors.Text = sf["MotionSensorInventory"].Value.ToString();
            Mics.Text = sf["ParabolicMicrophoneInventory"].Value.ToString();
            Cameras.Text = sf["PhotoCameraInventory"].Value.ToString();
            Trippods.Text = sf["TripodInventory"].Value.ToString();
            SoundSensors.Text = sf["SoundSensorInventory"].Value.ToString();
            Salt.Text = sf["SaltInventory"].Value.ToString();
            SanityPills.Text = sf["SanityMedicationInventory"].Value.ToString();
            money.Text = this.sf["PlayersMoney"].Value.ToString();
            prestige.Text = this.sf["Prestige"].Value.ToString();
            level.Text = this.sf["NewLevel"].Value.ToString();

        }

        private void MotionSensors2_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

       public async Task EnumSaveAsync()
        {
            FileSavePicker savePicker = new FileSavePicker();
             savePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });

            savePicker.SuggestedFileName = "SaveFile.txt";

            StorageFile file = await savePicker.PickSaveFileAsync();

            if (file != null)
            {
                try
                {
                    this.sf["EMFReaderInventory"].Value = Convert.ToInt32(EMFReader.Text);
                    this.sf["DOTSProjectorInventory"].Value = Convert.ToInt32(DOTS.Text);
                    this.sf["GhostWritingBookInventory"].Value = Convert.ToInt32(Books.Text);
                    this.sf["SpiritBoxInventory"].Value = Convert.ToInt32(spiritbox.Text);
                    this.sf["ThermometerInventory"].Value = Convert.ToInt32(Thermometers.Text);
                    this.sf["UVLightInventory"].Value = Convert.ToInt32(UVFlashlights.Text);
                    this.sf["FlashlightInventory"].Value = Convert.ToInt32(Flashlights.Text);
                    this.sf["VideoCameraInventory"].Value = Convert.ToInt32(videocameras.Text);
                    this.sf["CrucifixInventory"].Value = Convert.ToInt32(Crucifixs.Text);
                    this.sf["FirelightInventory"].Value = Convert.ToInt32(Candles.Text);
                    this.sf["HeadGearInventory"].Value = Convert.ToInt32(GoPro.Text);
                    this.sf["IgniterInventory"].Value = Convert.ToInt32(Lighters.Text);
                    this.sf["RepellentInventory"].Value = Convert.ToInt32(Sage.Text);
                    this.sf["MotionSensorInventory"].Value = Convert.ToInt32(MotionSensors.Text);
                    this.sf["ParabolicMicrophoneInventory"].Value = Convert.ToInt32(Mics.Text);
                    this.sf["PhotoCameraInventory"].Value = Convert.ToInt32(Cameras.Text);
                    this.sf["TripodInventory"].Value = Convert.ToInt32(Trippods.Text);
                    this.sf["SoundSensorInventory"].Value = Convert.ToInt32(SoundSensors.Text);
                    this.sf["SaltInventory"].Value = Convert.ToInt32(Salt.Text);
                    this.sf["SanityMedicationInventory"].Value = Convert.ToInt32(SanityPills.Text);
                    this.sf["PlayersMoney"].Value = Convert.ToInt32(money.Text);
                    this.sf["Prestige"].Value = Convert.ToInt32(prestige.Text);
                    this.sf["NewLevel"].Value = Convert.ToInt32(level.Text);

                    //this.sf["DOTSProjectorTier"].Value = dotstier.Value;
                    //this.sf["EMFReaderTier"].Value = emftier.Value;
                    //this.sf["GhostWritingBookTier"].Value = bookstier.Value;
                    //this.sf["SpiritBoxTier"].Value = spiritboxtier.Value;
                    //this.sf["ThermometerTier"].Value = thermometerstier.Value;
                    //this.sf["UVLightTier"].Value = uvflashlightstier.Value;
                    //this.sf["FlashlightTier"].Value = flashlighttier.Value;
                    //this.sf["VideoCameraTier"].Value = videocamerastier.Value;
                    //this.sf["CrucifixTier"].Value = crucifixstier.Value;
                    //this.sf["FirelightTier"].Value = candlestier.Value;
                    //this.sf["HeadGearTier"].Value = goprotier.Value;
                    //this.sf["IgniterTier"].Value = lighterstier.Value;
                    //this.sf["RepellentTier"].Value = sagetier.Value;
                    //this.sf["MotionSensorTier"].Value = motionsensorstier.Value;
                    //this.sf["ParabolicMicrophoneTier"].Value = micstier.Value;
                    //this.sf["PhotoCameraTier"].Value = camerastier.Value;
                    //this.sf["TripodTier"].Value = tripodstier.Value;
                    //this.sf["SoundSensorTier"].Value = soundsensorstier.Value;
                    //this.sf["SaltTier"].Value = salttier.Value;
                    //this.sf["SanityMedicationTier"].Value = sanitypillstier.Value;

                    var stream = await file.OpenAsync(FileAccessMode.ReadWrite);

                    using (StreamWriter sWriter = new StreamWriter(stream.AsStream()))
                    {
                        byte[] array = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this.sf, Formatting.Indented));
                        array = Crypto.EncryptSaveData(array);
                        sWriter.BaseStream.Write(array,0,array.Length);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }

        }

        [Microsoft.UI.Xaml.CustomAttributes.MUXPropertyDefaultValue(value = "true")]
        public bool SelectsOnInvoked { [Microsoft.UI.Xaml.CustomAttributes.MUXPropertyDefaultValue(value = "true")] get; [Microsoft.UI.Xaml.CustomAttributes.MUXPropertyDefaultValue(value = "true")] set; }

        private void ContentArea_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //SelectsOnInvoked = true;
            //ContentDialog leaving = new ContentDialog
            //{
            //    Title = "Save Stats?",
            //    Content = "You are about to leave the page and all progress will be lost, do you want to save?",
            //    PrimaryButtonText = "Yes",
            //    SecondaryButtonText = "No"
            //};

            //ContentDialogResult result = await leaving.ShowAsync();

            //if(result == ContentDialogResult.Primary)
            //{
            //    EnumSave();
            //    SelectsOnInvoked = false;
            //}else if (result == ContentDialogResult.Secondary) {
            //    SelectsOnInvoked = true;
            //}
            //else
            //{
            //    Environment.Exit(0);

            //}
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EnumSaveAsync();
        }

        private void SetButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EMFReader.Text = SetAll.Text;
            DOTS.Text = SetAll.Text;
            Books.Text = SetAll.Text;
            spiritbox.Text = SetAll.Text;
            Thermometers.Text = SetAll.Text;
            UVFlashlights.Text = SetAll.Text;
            Flashlights.Text = SetAll.Text;
            videocameras.Text = SetAll.Text;
            Crucifixs.Text = SetAll.Text;
            Candles.Text = SetAll.Text;
            GoPro.Text = SetAll.Text;
            Lighters.Text = SetAll.Text;
            Sage.Text = SetAll.Text;
            MotionSensors.Text = SetAll.Text;
            Mics.Text = SetAll.Text;
            Cameras.Text = SetAll.Text;
            Trippods.Text = SetAll.Text;
            SoundSensors.Text = SetAll.Text;
            Salt.Text = SetAll.Text;
            SanityPills.Text = SetAll.Text;

        }

        private async Task loadAsync()
        {
            if (saveOpen == false)
            {
                final = UserNameStr.Split("\\");

                var file3 = $"C://Users/{final[1]}/AppData/LocalLow/Kinetic Games/Phasmophobia/";
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                openPicker.FileTypeFilter.Add(".txt");

                StorageFile file = await openPicker.PickSingleFileAsync();

                if (file != null)
                {
                    try
                    {
                        var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                        using (StreamReader sReader = new StreamReader(stream.AsStream()))
                        {
                            var bytes = default(byte[]);
                            using (var memstream = new MemoryStream())
                            {
                                sReader.BaseStream.CopyTo(memstream);
                                bytes = memstream.ToArray();

                                byte[] bytes2 = Crypto.DecryptSaveData(bytes);
                                this.sf = JsonConvert.DeserializeObject<Dictionary<string, SaveGenericProperty>>(Encoding.UTF8.GetString(bytes2));
                                saveOpen = true;
                                this.EnumFields();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void ContentArea_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void open_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            loadAsync();
        }
    }
}
