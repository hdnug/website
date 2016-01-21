using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HdnugAnnouncementFormatter
{
    public class MeetingAnnouncement:INotifyPropertyChanged 
    {

        public MeetingAnnouncement()
        {
            this.MeetingLocation =
@"Microsoft Houston Meeting Facility 
 2000 W Sam Houston Pkwy S, Suite 350 
 Houston, TX 77042";
            this.MeetingDate = DateTime.Now.Date;
        }

        private string title;

        private string speakerFirstName;

        private string speakerLastName;

        private string sessionAbstract;

        private string aboutSpeaker;

        private string sponsorName;

        private string sponsorUrl;

        private string sponsorMessage;

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                
                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        public string SpeakerFirstName
        {
            get
            {
                return this.speakerFirstName;
            }
            set
            {
                this.speakerFirstName = value;
                OnPropertyChanged("SpeakerFirstName");
            }
        }

        public string SpeakerLastName
        {
            get
            {
                return this.speakerLastName;
            }
            set
            {
                this.speakerLastName = value;
                OnPropertyChanged("SpeakerLastName");
            }
        }

        public string SessionAbstract
        {
            get
            {
                return this.sessionAbstract;
            }
            set
            {
                this.sessionAbstract = value;
                OnPropertyChanged("SessionAbstract");
            }
        }

        public string AboutSpeaker
        {
            get
            {
                return this.aboutSpeaker;
            }
            set
            {
                this.aboutSpeaker = value;
                OnPropertyChanged("AboutSpeaker");
            }
        }


        public string SponsorName
        {
            get
            {
                return this.sponsorName;
            }
            set
            {
                this.sponsorName = value;
                OnPropertyChanged("SponsorName");
            }
        }

        public string SponsorUrl
        {
            get
            {
                return this.sponsorUrl;
            }
            set
            {
                this.sponsorUrl = value;
                OnPropertyChanged("SponsorUrl");
            }
        }

        public string SponsorMessage
        {
            get
            {
                return this.sponsorMessage;
            }
            set
            {
                this.sponsorMessage = value;
                OnPropertyChanged("SponsorMessage");
            }
        }

        public DateTime MeetingDate { get; set; }

        public string MeetingLocation { get; set; }

        public string PostingHtml
        {
            get
            {
                return String.Format(
                    "<h3>{0}</h3> <b>Featured Speaker: {1} {2}</b><p>{3}</p> <p><b>About {1}:</b><br/>{4}</p>",
                    this.Title, this.SpeakerFirstName, this.SpeakerLastName, this.SessionAbstract, this.AboutSpeaker);
            }
        }

        public string FacebookText
        {
            get
            {
                return String.Format(
@"Featured Speaker: {0} {1}
{2}
About {0}:
{3}

-------------------------------------------------------------------------------
Sponsor: {4}

{5}",
this.SpeakerFirstName, this.SpeakerLastName, this.SessionAbstract, this.AboutSpeaker, this.SponsorName, this.SponsorMessage
                    );
            }
        }

        public string LinkedInText
        {
            get
            {
                return string.Format(
@"Featured Speaker: {0} {1}
 When: {2:D} - 6:30 PM to 8:30 PM. 
 Where: {3} 
 {4}
 About {0}: 
 {5}
 -------------------------------------------------------------------------------- 
 Sponsor: {6} 
 {7}",
SpeakerFirstName, SpeakerLastName, MeetingDate, MeetingLocation, SessionAbstract, AboutSpeaker, SponsorName, SponsorMessage);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("PostingHtml"));
                PropertyChanged(this, new PropertyChangedEventArgs("LinkedInText"));
                PropertyChanged(this, new PropertyChangedEventArgs("FacebookText"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
