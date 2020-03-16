using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMusicMasters.Models;

namespace StockMusicMasters.Data
{
    public class FakeMusicRepository : IMusicRepository
    {
        private static List<MusicTrack> musicTracks = new List<MusicTrack>();

        public List<MusicTrack> MusicTracks { get { return musicTracks; } }

        private static List<MusicTrack> currentMusicTracks = new List<MusicTrack>();

        public List<MusicTrack> CurrentMusicTracks { get { return currentMusicTracks; } set { currentMusicTracks = value; } }

        private static List<MoodTag> moodList = new List<MoodTag>();

        public List<MoodTag> MoodList { get { return moodList; } }

        private static List<InstrumentTag> instrumentList = new List<InstrumentTag>();

        public List<InstrumentTag> InstrumentList { get { return instrumentList; } }

        private static List<GenreTag> genreList = new List<GenreTag>();

        public List<GenreTag> GenreList { get { return genreList; } }

        private static string currentMood = "";

        public string CurrentMood { get { return currentMood; } set { currentMood = value; } }

        private static string currentInstrument = "";

        public string CurrentInstrument { get { return currentInstrument; } set { currentInstrument = value; } }

        private static string currentGenre = "";

        public string CurrentGenre { get { return currentGenre; } set { currentGenre = value; } }

        public List<MusicTrackInstrumentTag> MusicTrackInstrumentTags { get { return musicTrackInstrumentTags; } }

        private static List<MusicTrackInstrumentTag> musicTrackInstrumentTags = new List<MusicTrackInstrumentTag>();

        public List<MusicTrackMoodTag> MusicTrackMoodTags { get { return musicTrackMoodTags; } }

        private static List<MusicTrackMoodTag> musicTrackMoodTags = new List<MusicTrackMoodTag>();

        public FakeMusicRepository()
        {
            if (MusicTracks.Count == 0)
            {
                AddSeedData();
            }
        }

        public void SaveSongToDatabase(MusicTrack musicTrack)
        {

        }

        public void AddMusicTrack(MusicTrack musicTrack)
        {
            musicTracks.Add(musicTrack);
        }

        public MusicTrack GetMusicTrackByName(string name)
        {
            MusicTrack musicTrack = musicTracks.Find(m => m.Name == name);
            return musicTrack;
        }

        public List<MusicTrack> GetMusicTracksByMood(List<MusicTrack> tracks, string moodSelect)
        {
            List<MusicTrack> musicTracksByMood = (List<MusicTrack>)tracks.Where(m => m.Moods.Any(mood => mood.Tag == moodSelect)).ToList();
            return musicTracksByMood;
        }

        public List<MusicTrack> GetMusicTracksByInstrument(List<MusicTrack> tracks, string instrumentSelect)
        {
            List<MusicTrack> musicTracksByInstrument = (List<MusicTrack>)tracks.Where(m => m.Instruments.Any(instrument => instrument.Tag == instrumentSelect)).ToList();
            return musicTracksByInstrument;
        }

        public List<MusicTrack> GetMusicTracksByGenre(List<MusicTrack> tracks, string genreSelect)
        {
            List<MusicTrack> musicTrackByGenre = (List<MusicTrack>)tracks.Where(m => m.Genre.Tag == genreSelect).ToList();
            return musicTrackByGenre;
        }

        public void AddSeedData()
        {
            //List<string> allMoods = new List<string>{ "beautiful", "dark", "dramatic", "emotional", "energetic", "epic", "fun", "gentle", "happy", "hopeful", "inspirational", "joyful", "light", "motivational", "optimistic", "peaceful", "powerful", "relaxing", "romantic", "sad", "sentimental", "suspenseful", "upbeat", "uplifting" };
            //moodList.AddRange(allMoods);

            //List<string> allInstruments = new List<string> { "acoustic guitar", "bass", "cello", "percussion", "piano", "strings", "synth", "violin" };
            //instrumentList.AddRange(allInstruments);

            //List<string> allGenres = new List<string> { "Acoustic", "Ambient", "Cinematic", "Corporate", "Electronica", "Holiday", "Other", "Pop", "Rock" };
            //genreList.AddRange(allGenres);

            GenreTag cinematic = new GenreTag();
            cinematic.Tag = "Cinematic";
            GenreTag acoustic = new GenreTag();
            acoustic.Tag = "Acoustic";

            MoodTag beautiful = new MoodTag();
            beautiful.Tag = "beautiful";
            MoodTag dark = new MoodTag();
            dark.Tag = "dark";
            MoodTag dramatic = new MoodTag();
            dramatic.Tag = "dramatic";
            MoodTag emotional = new MoodTag();
            emotional.Tag = "emotional";
            MoodTag energetic = new MoodTag();
            energetic.Tag = "energetic";
            MoodTag epic = new MoodTag();
            epic.Tag = "epic";
            MoodTag fun = new MoodTag();
            fun.Tag = "fun";
            MoodTag gentle = new MoodTag();
            gentle.Tag = "gentle";
            MoodTag happy = new MoodTag();
            happy.Tag = "happy";
            MoodTag hopeful = new MoodTag();
            hopeful.Tag = "hopeful";
            MoodTag inspirational = new MoodTag();
            inspirational.Tag = "inspirational";
            MoodTag joyful = new MoodTag();
            joyful.Tag = "joyful";
            MoodTag light = new MoodTag();
            light.Tag = "light";
            MoodTag motivational = new MoodTag();
            motivational.Tag = "motivational";
            MoodTag optimistic = new MoodTag();
            optimistic.Tag = "optimistic";
            MoodTag peaceful = new MoodTag();
            peaceful.Tag = "peaceful";
            MoodTag powerful = new MoodTag();
            powerful.Tag = "powerful";
            MoodTag relaxing = new MoodTag();
            relaxing.Tag = "relaxing";
            MoodTag romantic = new MoodTag();
            romantic.Tag = "romantic";
            MoodTag sentimental = new MoodTag();
            sentimental.Tag = "sentimental";
            MoodTag suspenseful = new MoodTag();
            suspenseful.Tag = "suspenseful";
            MoodTag upbeat = new MoodTag();
            upbeat.Tag = "upbeat";
            MoodTag uplifting = new MoodTag();
            uplifting.Tag = "uplifting";

            InstrumentTag acousticGuitar = new InstrumentTag();
            acousticGuitar.Tag = "acoustic guitar";
            InstrumentTag bass = new InstrumentTag();
            bass.Tag = "bass";
            InstrumentTag cello = new InstrumentTag();
            cello.Tag = "cello";
            InstrumentTag percussion = new InstrumentTag();
            percussion.Tag = "percussion";
            InstrumentTag piano = new InstrumentTag();
            piano.Tag = "piano";
            InstrumentTag strings = new InstrumentTag();
            strings.Tag = "strings";
            InstrumentTag synth = new InstrumentTag();
            synth.Tag = "synth";
            InstrumentTag violin = new InstrumentTag();
            violin.Tag = "violin";

            OtherTag beach = new OtherTag();
            beach.Tag = "beach";
            OtherTag beauty = new OtherTag();
            beauty.Tag = "beauty";
            OtherTag brave = new OtherTag();
            brave.Tag = "brave";


            List<MoodTag> moods = new List<MoodTag> { beautiful, emotional, gentle, hopeful, inspirational, optimistic, peaceful, relaxing, romantic, sentimental, uplifting };
            List<InstrumentTag> instruments = new List<InstrumentTag> { cello, piano, violin };
            List<OtherTag> tags = new List<OtherTag> { beauty };
            MusicTrack song = new MusicTrack();
            song.Name = "Beautiful Cinematic Piano";
            song.Genre = cinematic;
            song.FileName = "Beautiful-Cinematic-Piano.mp3";
            song.Moods = moods;
            song.AddInstruments(instruments);
            song.AddTags(tags);
            AddMusicTrack(song);

            moods = new List<MoodTag> { dark, dramatic, energetic, epic, inspirational, motivational, powerful, suspenseful, upbeat };
            instruments = new List<InstrumentTag> { cello, percussion, violin, strings };
            tags = new List<OtherTag> { beauty, brave };
            song = new MusicTrack();
            song.Name = "Epic Cinematic Trailer";
            song.Genre = cinematic;
            song.FileName = "Epic-Cinematic-Trailer.mp3";
            song.Moods = moods;
            song.AddInstruments(instruments);
            song.AddTags(tags);
            AddMusicTrack(song);

            instruments = new List<InstrumentTag> { percussion };
            tags = new List<OtherTag> { brave };
            song = new MusicTrack();
            song.Name = "Epic Upbeat Cinematic Percussion";
            song.Genre = cinematic;
            song.FileName = "Epic-Upbeat-Cinematic-Percussion.mp3";
            song.Moods = moods;
            song.AddInstruments(instruments);
            song.AddTags(tags);
            AddMusicTrack(song);

            moods = new List<MoodTag> { energetic, fun, happy, hopeful, inspirational, joyful, light, optimistic, upbeat, uplifting };
            instruments = new List<InstrumentTag> { acousticGuitar, bass, piano, percussion, synth };
            tags = new List<OtherTag> { beach };
            song = new MusicTrack();
            song.Name = "Happy Acoustic Summer Whistle";
            song.Genre = acoustic;
            song.FileName = "Happy-Acoustic-Summer-Whistle.mp3";
            song.Moods = moods;
            song.AddInstruments(instruments);
            song.AddTags(tags);
            AddMusicTrack(song);
        }

        public GenreTag GetGenreTagFromDataBase(string genre)
        {
            throw new NotImplementedException();
        }

        public MoodTag GetMoodTagFromDatabase(string mood)
        {
            throw new NotImplementedException();
        }

        public InstrumentTag GetInstrumentTagFromDatabase(string instrument)
        {
            throw new NotImplementedException();
        }

        public void UpdateSongInDatabase(MusicTrack musicTrack)
        {
            throw new NotImplementedException();
        }

        public void DeleteSongFromDatabase(MusicTrack musicTrack)
        {
            throw new NotImplementedException();
        }

        public void DeleteMusicTrackMoodTags(MusicTrack musicTrack)
        {
            throw new NotImplementedException();
        }

        public void DeleteMusicTrackInstrumentTags(MusicTrack musicTrack)
        {
            throw new NotImplementedException();
        }

        public MusicTrack GetMusicTrackById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
