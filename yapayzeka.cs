using System;

class HBN
{
    static int V = 9;
    int minDistance(int[] dist,
                    bool[] sptSet)
    {

        // Min. Değeri başlat
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }

    // Yazdırmak için program işlevi
    // inşa edilen mesafe dizisi
    void printSolution(int[] dist)
    {
        Console.Write("Köşe \t\t Hedefe "
                      + "Uzaklık \n");
        for (int i = 0; i < V; i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }

    // Dijkstraları uygulayan fonksiyon
    // tek kaynaklı en kısa yol algoritması
    // matris gösterimi
    void dijkstra(int[,] graph, int src)
    {
        int[] dist = new int[V];
        // en kısa tutacak
        // src ile i arasındaki mesafe
        // tepe noktası varsa sptSet[i] geçerli olur
        // src - i sonlandırıldı
        bool[] sptSet = new bool[V];
        // Tüm mesafeleri şu şekilde başlat:
        // INFINITE ve stpSet [] false olacak
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }


        // Kaynak tepe noktasının mesafesi
        // her zaman sıfır
        dist[src] = 0;


        // Tüm köşeler için en kısa yolu bulun
        for (int count = 0; count < V - 1; count++)
        {
            // Minimum mesafe tepe noktasını seçin
            int u = minDistance(dist, sptSet);

            // Seçilmiş tepe noktasını işlenmiş olarak işaretleme
            sptSet[u] = true;

            // dağıtım değerini güncelle
            // toplanan tepe noktasının köşeleri.
            for (int v = 0; v < V; v++)

                // dist [v] 'yi yalnızca içinde değilse güncelleyin
                if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }

        //mesafe dizisini yazdır
        printSolution(dist);
    }

    // Sürücü Kodu
    public static void Main()
    {
        /* Örneği oluşturalım
yukarıda anlatılan grafik */
        int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
        HBN t = new HBN();
        t.dijkstra(graph, 0);
    }
}