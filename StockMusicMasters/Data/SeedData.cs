using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StockMusicMasters.Models;

namespace StockMusicMasters.Data
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if (!context.MusicTracks.Any())
            {
                // Adding Genre Tags
                GenreTag acoustic = new GenreTag();
                acoustic.Tag = "Acoustic";
                context.GenreTags.Add(acoustic);
                GenreTag ambient = new GenreTag();
                ambient.Tag = "Ambient";
                context.GenreTags.Add(ambient);
                GenreTag cinematic = new GenreTag();
                cinematic.Tag = "Cinematic";
                context.GenreTags.Add(cinematic);
                GenreTag coporate = new GenreTag();
                coporate.Tag = "Coporate";
                context.GenreTags.Add(coporate);
                GenreTag electronica = new GenreTag();
                electronica.Tag = "Electronica";
                context.GenreTags.Add(electronica);
                GenreTag holiday = new GenreTag();
                holiday.Tag = "Holiday";
                context.GenreTags.Add(holiday);
                GenreTag other = new GenreTag();
                other.Tag = "Other";
                context.GenreTags.Add(other);
                GenreTag pop = new GenreTag();
                pop.Tag = "Pop";
                context.GenreTags.Add(pop);
                GenreTag rock = new GenreTag();
                rock.Tag = "Rock";
                context.GenreTags.Add(rock);

                // Adding Mood Tags
                MoodTag beautiful = new MoodTag();
                beautiful.Tag = "beautiful";
                context.MoodTags.Add(beautiful);
                MoodTag dark = new MoodTag();
                dark.Tag = "dark";
                context.MoodTags.Add(dark);
                MoodTag dramatic = new MoodTag();
                dramatic.Tag = "dramatic";
                context.MoodTags.Add(dramatic);
                MoodTag emotional = new MoodTag();
                emotional.Tag = "emotional";
                context.MoodTags.Add(emotional);
                MoodTag energetic = new MoodTag();
                energetic.Tag = "energetic";
                context.MoodTags.Add(energetic);
                MoodTag epic = new MoodTag();
                epic.Tag = "epic";
                context.MoodTags.Add(epic);
                MoodTag fun = new MoodTag();
                fun.Tag = "fun";
                context.MoodTags.Add(fun);
                MoodTag gentle = new MoodTag();
                gentle.Tag = "gentle";
                context.MoodTags.Add(gentle);
                MoodTag happy = new MoodTag();
                happy.Tag = "happy";
                context.MoodTags.Add(happy);
                MoodTag hopeful = new MoodTag();
                hopeful.Tag = "hopeful";
                context.MoodTags.Add(hopeful);
                MoodTag inspirational = new MoodTag();
                inspirational.Tag = "inspirational";
                context.MoodTags.Add(inspirational);
                MoodTag joyful = new MoodTag();
                joyful.Tag = "joyful";
                context.MoodTags.Add(joyful);
                MoodTag light = new MoodTag();
                light.Tag = "light";
                context.MoodTags.Add(light);
                MoodTag motivational = new MoodTag();
                motivational.Tag = "motivational";
                context.MoodTags.Add(motivational);
                MoodTag optimistic = new MoodTag();
                optimistic.Tag = "optimistic";
                context.MoodTags.Add(optimistic);
                MoodTag peaceful = new MoodTag();
                peaceful.Tag = "peaceful";
                context.MoodTags.Add(peaceful);
                MoodTag powerful = new MoodTag();
                powerful.Tag = "powerful";
                context.MoodTags.Add(powerful);
                MoodTag relaxing = new MoodTag();
                relaxing.Tag = "relaxing";
                context.MoodTags.Add(relaxing);
                MoodTag romantic = new MoodTag();
                romantic.Tag = "romantic";
                context.MoodTags.Add(romantic);
                MoodTag sentimental = new MoodTag();
                sentimental.Tag = "sentimental";
                context.MoodTags.Add(sentimental);
                MoodTag suspenseful = new MoodTag();
                suspenseful.Tag = "suspenseful";
                context.MoodTags.Add(suspenseful);
                MoodTag upbeat = new MoodTag();
                upbeat.Tag = "upbeat";
                context.MoodTags.Add(upbeat);
                MoodTag uplifting = new MoodTag();
                uplifting.Tag = "uplifting";
                context.MoodTags.Add(uplifting);

                // Add Instrument Tags
                InstrumentTag acousticGuitar = new InstrumentTag();
                acousticGuitar.Tag = "acoustic guitar";
                context.InstrumentTags.Add(acousticGuitar);
                InstrumentTag bass = new InstrumentTag();
                bass.Tag = "bass";
                context.InstrumentTags.Add(bass);
                InstrumentTag cello = new InstrumentTag();
                cello.Tag = "cello";
                context.InstrumentTags.Add(cello);
                InstrumentTag percussion = new InstrumentTag();
                percussion.Tag = "percussion";
                context.InstrumentTags.Add(percussion);
                InstrumentTag piano = new InstrumentTag();
                piano.Tag = "piano";
                context.InstrumentTags.Add(piano);
                InstrumentTag strings = new InstrumentTag();
                strings.Tag = "strings";
                context.InstrumentTags.Add(strings);
                InstrumentTag synth = new InstrumentTag();
                synth.Tag = "synth";
                context.InstrumentTags.Add(synth);
                InstrumentTag violin = new InstrumentTag();
                violin.Tag = "violin";
                context.InstrumentTags.Add(violin);

                // Add Other Tags
                OtherTag beach = new OtherTag();
                beach.Tag = "beach";
                context.OtherTags.Add(beach);
                OtherTag beauty = new OtherTag();
                beauty.Tag = "beauty";
                context.OtherTags.Add(beauty);
                OtherTag brave = new OtherTag();
                brave.Tag = "brave";
                context.OtherTags.Add(brave);


                // Add Songs
                MusicTrack song = new MusicTrack();
                song.Name = "Beautiful Cinematic Piano";
                song.Genre = cinematic;
                song.FileName = "Beautiful-Cinematic-Piano.mp3";

                List<MoodTag> moods = new List<MoodTag> { beautiful, emotional, gentle, hopeful, inspirational, optimistic, peaceful, relaxing, romantic, sentimental, uplifting };
                var m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = beautiful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = emotional;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = gentle;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = hopeful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = inspirational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = optimistic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = peaceful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = relaxing;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = romantic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = uplifting;
                song.MusicTrackMoodTags.Add(m);

                List<InstrumentTag> instruments = new List<InstrumentTag> { cello, piano, violin };

                var i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = cello;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = piano;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = violin;
                song.MusicTrackInstrumentTags.Add(i);

                context.MusicTracks.Add(song);

                song = new MusicTrack();
                song.Name = "Epic Cinematic Trailer";
                song.Genre = cinematic;
                song.FileName = "Epic-Cinematic-Trailer.mp3";

                moods = new List<MoodTag> { dark, dramatic, energetic, epic, inspirational, motivational, powerful, suspenseful, upbeat };

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = dark;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = dramatic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = energetic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = epic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = inspirational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = motivational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = powerful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = suspenseful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = upbeat;
                song.MusicTrackMoodTags.Add(m);

                instruments = new List<InstrumentTag> { cello, percussion, violin, strings };

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = cello;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = percussion;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = strings;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = violin;
                song.MusicTrackInstrumentTags.Add(i);


                context.MusicTracks.Add(song);

                song = new MusicTrack();
                song.Name = "Epic Upbeat Cinematic Percussion";
                song.Genre = cinematic;
                song.FileName = "Epic-Upbeat-Cinematic-Percussion.mp3";

                moods = new List<MoodTag> { dark, dramatic, energetic, epic, inspirational, motivational, powerful, suspenseful, upbeat };

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = dark;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = dramatic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = energetic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = epic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = inspirational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = motivational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = powerful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = suspenseful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = upbeat;
                song.MusicTrackMoodTags.Add(m);

                instruments = new List<InstrumentTag> { percussion };

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = percussion;
                song.MusicTrackInstrumentTags.Add(i);

                var tags = new List<OtherTag> { brave };

                var t = new MusicTrackOtherTag();
                t.MusicTrack = song;
                t.OtherTag = brave;
                song.MusicTrackOtherTags.Add(t);

                context.MusicTracks.Add(song);


                song = new MusicTrack();
                song.Name = "Happy Acoustic Summer Whistle";
                song.Genre = acoustic;
                song.FileName = "Happy-Acoustic-Summer-Whistle.mp3";

                moods = new List<MoodTag> { energetic, fun, happy, hopeful, inspirational, joyful, light, optimistic, upbeat, uplifting };

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = energetic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = fun;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = happy;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = hopeful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = inspirational;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = joyful;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = light;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = optimistic;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = upbeat;
                song.MusicTrackMoodTags.Add(m);

                m = new MusicTrackMoodTag();
                m.MusicTrack = song;
                m.MoodTag = uplifting;
                song.MusicTrackMoodTags.Add(m);

                instruments = new List<InstrumentTag> { acousticGuitar, bass, piano, percussion, synth };

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = acousticGuitar;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = bass;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = piano;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = percussion;
                song.MusicTrackInstrumentTags.Add(i);

                i = new MusicTrackInstrumentTag();
                i.MusicTrack = song;
                i.InstrumentTag = synth;
                song.MusicTrackInstrumentTags.Add(i);

                tags = new List<OtherTag> { beach };

                t = new MusicTrackOtherTag();
                t.MusicTrack = song;
                t.OtherTag = beach;
                song.MusicTrackOtherTags.Add(t);

                context.MusicTracks.Add(song);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////// SAVE CHANGES ///////////////////////////////
                context.SaveChanges();
            }
        }
    }
}
