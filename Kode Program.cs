using System; // biar bisa pake console buat input output

namespace TiketBioskop // nama tugas/project yang saya kerjain
{
    class Program // yang dipake buat ngejalanin program
    {
        static void Main() // program dimulai dari sini
        {
            int totalBayar = 0; // buat nyimpen total duit semua transaksi
            int jumlahTransaksi = 0; // buat ngitung udah berapa kali beli
            int totalTiket = 0; // buat ngitung total tiket yang dibeli
            int harga = 50000; // harga 1 tiketnya

            while (true) // biar programnya ngulang terus
            {
                if (jumlahTransaksi > 5) // cuma bisa 5x transaksi
                {
                    Console.WriteLine("udah lebih 5x, stop."); // kasih info ke user
                    break; // keluar dari loop
                }

                Console.Write("Jumlah tiket (1-5): "); // minta user masukin jumlah tiket
                int jumlah = Convert.ToInt32(Console.ReadLine()); // ambil input terus diubah ke angka


                if (jumlah < 1 || jumlah > 5) // ngecek input valid atau engga
                {
                    Console.WriteLine("input salah, ulang."); // kasih tau kalo salah
                    continue; // balik ke awal loop lagi
                }

                jumlahTransaksi++; // nambah jumlah transaksi
                totalTiket += jumlah; // nambah total tiket yang udah dibeli
                int total = jumlah * harga; // ngitung total harga sebelum diskon

                int kategori = 0; // tentuin dapet diskon apa nggak
                if (jumlah >= 5 && jumlahTransaksi <= 3)     kategori = 1; // kalo beli 5 tiket dan transaksi masih 1-3
                else if (jumlah >= 5 && jumlahTransaksi > 3) kategori = 2; // kalo beli 5 tiket tapi transaksi udah lewat 3
                else                                          kategori = 3; // selain itu ga dapet diskon

                switch (kategori) // bagian ngasih diskon pake switch
                {
                    case 1:
                        total = total - (total * 10 / 100); // potongan 10%
                        Console.WriteLine("dapet diskon 10%");
                        break; // keluar dari switch
                    case 2:
                        total = total - (total * 5 / 100); // potongan 5%
                        Console.WriteLine("diskon 5% aja");
                        break; // keluar dari switch
                    case 3:
                        Console.WriteLine("ga dapet diskon");
                        break; // keluar dari switch
                }

                totalBayar += total; // masukin total ini ke total keseluruhan
                Console.WriteLine("bayar sekarang: Rp " + total); // nampilin total bayar

                if (jumlahTransaksi >= 5)
                {
                    Console.WriteLine("udah 5x transaksi, selesai.");
                    break;
                }

                Console.Write("beli lagi? (y/n): "); // nanya mau lanjut atau engga
                string jawab = Console.ReadLine()!; // ambil jawaban user
                if (jawab != "y" && jawab != "Y") break; // kalo jawabannya bukan y/Y, berhenti
            }

            Console.WriteLine("\n--- rekap ---"); // judul rekap 
            Console.WriteLine("transaksi : " + jumlahTransaksi + "x"); // nampilin total transaksi
            Console.WriteLine("tiket     : " + totalTiket + " tiket"); // nampilin total tiket
            Console.WriteLine("total     : Rp " + totalBayar); // nampilin total pembayaran
        }
    }
}