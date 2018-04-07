using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFEmojiExample.ViewModels
{
    public class XFEmojiExampleViewModel : INotifyPropertyChanged
    {
        public string BikingBtnLbl => $"Biking {bikingEmoji}";
        public string HelloBtnLbl => $"Hello {manTechnologiest}";
        public event PropertyChangedEventHandler PropertyChanged;

        string lblValue;
        public string LblValue
        {
            get => lblValue;
            set
            {
                lblValue = value;
                RaisePropertyChanged();
            }
        }

        #region Emojis
        // person biking => http://www.unicode.org/emoji/charts/full-emoji-list.html#1f6b4
        static Emoji bikingEmoji = new Emoji(0x1F6B4);
        // man technologist => http://www.unicode.org/emoji/charts/full-emoji-list.html#1f468_200d_1f4bb
        static Emoji manTechnologiest = new Emoji(new int[] { 0x1F468, 0x200D, 0x1F4BB });
        // cat face => http://www.unicode.org/emoji/charts/full-emoji-list.html#1f431
        static Emoji catFaceEmoji = new Emoji(0x1F431);
        // => face with tears of joy => http://www.unicode.org/emoji/charts/full-emoji-list.html#1f602     
        static Emoji faceWithTearsOfJoyEmoji = new Emoji(0x1F602);
        // sun => http://www.unicode.org/emoji/charts/full-emoji-list.html#2600 
        static Emoji sunEmoji = new Emoji(0x2600);
        // sunglasses => http://www.unicode.org/emoji/charts/full-emoji-list.html#1f576     
        static Emoji sunglassesEmoji = new Emoji(0x1F576);
        #endregion

        public ICommand ChangeLblCmd { get; }

        public XFEmojiExampleViewModel()
        {
            ChangeLblCmd = new Command<string>((action) =>
            {
                switch (action)
                {
                    case "hello":
                        LblValue = $"Hello world {manTechnologiest}! My {catFaceEmoji} is {faceWithTearsOfJoyEmoji}!";
                        break;
                    default:
                        LblValue = $"The {sunEmoji} is out, put on {sunglassesEmoji} and go {bikingEmoji}!";
                        break;
                }
            });
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
