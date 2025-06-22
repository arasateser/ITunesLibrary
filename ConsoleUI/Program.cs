//// See https://aka.ms/new-console-template for more information
//using Business.Concrete;
//using Core.DataAccess.EntityFramework;
//using DataAccess.Concrete.EntityFramework;

//Console.WriteLine("Hello, World!");


////TrackTest();

//static void TrackTest()
//{
//    TrackManager trackManager = new TrackManager(new EfTrackDal());
//    var result = trackManager.GetTracksByMiliseconds(284000, 285000);
//    if (result.Success == true)
//    {
//        //Console.WriteLine(result.Data.TrackId + " " + result.Data.Name);
//        foreach (var item in result.Data)
//        {
//            Console.WriteLine(item.TrackId + " " + item.Name + " " + item.Milliseconds);
//        }
//    }
//}

////ArtistTest();
//static void ArtistTest()
//{
//    ArtistManager artistManager = new ArtistManager(new EfArtistDal());
//    var result = artistManager.GetByArtistId(21);
//    if (result.Success == true)
//    {
//        Console.WriteLine(result.Data.ArtistId + " " + result.Data.Name);
//        //foreach (var item in result.Data)
//        //{
//        //    Console.WriteLine(item.ArtistId + " " + item.Name);
//        //}
//    }
//}

//AlbumTest();

//static void AlbumTest()
//{
//    AlbumManager albumManager = new AlbumManager(new EfAlbumDal());
//    var result1 = albumManager.GetByAlbumId(1);
//    var result2 = albumManager.GetAllAlbums();
//    Console.WriteLine(result1.Data.AlbumId + " / " + result1.Data.Title + " / " + result1.Message);
//    if (result2.Success == true)
//    {
//        foreach (var item in result2.Data)
//        {
//            Console.WriteLine(item.AlbumId + " / " + item.Title + " / " + result2.Message);
//        }
//    }
//}

