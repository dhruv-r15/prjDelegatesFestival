namespace prjDelegatesFestival
{
    public delegate void BandAnnouncementDelegate(string bandName);
    public delegate void StagePerformanceDelegate();

    internal class Program
    {
        public class Band
        {
            public string Name { get; set; }
            public string Genre { get; set; }
            public DateTime TimeSlot { get; set; }
        }

        
        public class FestivalPlanner
        {
            private List<Band> bands = new List<Band>();

            
            public delegate void BandAnnouncementDelegate(Band band);
            public delegate void StagePerformanceDelegate();

            private BandAnnouncementDelegate announcementDelegate;
            private StagePerformanceDelegate performanceDelegate;

            
            public void RegisterBandForAnnouncement(BandAnnouncementDelegate announcementDelegate)
            {
                this.announcementDelegate = announcementDelegate;
            }

            public void RegisterStagePerformance(StagePerformanceDelegate performanceDelegate)
            {
                this.performanceDelegate = performanceDelegate;
            }

            public void AddBandToLineup(Band band)
            {
                bands.Add(band);
            }

            public void SimulateFestival()
            {
                bands.Sort((a, b) => a.TimeSlot.CompareTo(b.TimeSlot));

                foreach (Band band in bands)
                {
                    announcementDelegate(band);
                    Console.WriteLine("Setting up the stage...");
                    performanceDelegate();
                    Console.WriteLine($"{band.Name} is performing on stage!");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {

            FestivalPlanner festivalPlanner = new FestivalPlanner();

            
            festivalPlanner.RegisterBandForAnnouncement(AnnounceBand);
            festivalPlanner.RegisterStagePerformance(SetupStage);

            
            festivalPlanner.AddBandToLineup(new Band { Name = "Fall Out Boy", Genre = "Rock", TimeSlot = new DateTime(2024, 6, 15, 18, 0, 0) });
            festivalPlanner.AddBandToLineup(new Band { Name = "Blue Giant", Genre = "Jazz", TimeSlot = new DateTime(2024, 6, 15, 20, 0, 0) });
            festivalPlanner.AddBandToLineup(new Band { Name = "Vikkstar123", Genre = "EDM", TimeSlot = new DateTime(2024, 6, 15, 22, 0, 0) });

            
            festivalPlanner.SimulateFestival();
        }

        static void AnnounceBand(Band band)
        {
            Console.WriteLine($"Announcing {band.Name} ({band.Genre}) at {band.TimeSlot.ToString("dd/MM/yyyy hh:mm tt")}");
        }

        static void SetupStage()
        {
            Console.WriteLine("Stage setup complete!");
        }

    }
}

