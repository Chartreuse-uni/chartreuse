import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class Map {
    private int goldToWin; 

    private final char[][] map_1 = {
        "####################".toCharArray(),
        "#...............E..#".toCharArray(),
        "#...G..............#".toCharArray(),
        "#.........G........#".toCharArray(),
        "#..................#".toCharArray(),
        "#..................#".toCharArray(),
        "#...G..............#".toCharArray(),
        "#.............G....#".toCharArray(),
        "####################".toCharArray()
    };

    private final char[][] map_2 = {
        "####################".toCharArray(),
        "#.........G........#".toCharArray(),
        "#..................#".toCharArray(),
        "#.........G........#".toCharArray(),
        "#.........E........#".toCharArray(),
        "#................G.#".toCharArray(),
        "#..................#".toCharArray(),
        "#..G...............#".toCharArray(),
        "####################".toCharArray()
    };

    private final char[][] map_3 = {
        "####################".toCharArray(),
        "#..............GE..#".toCharArray(),
        "#...G..............#".toCharArray(),
        "#..................#".toCharArray(),
        "#.G................#".toCharArray(),
        "#...............G..#".toCharArray(),
        "#..................#".toCharArray(),
        "#....G.............#".toCharArray(),
        "####################".toCharArray()
    };



    // Return the map
    public char[][] get_Map(int mapNumber) {
        if (mapNumber == 1){
            goldToWin = 3;
            return map_1;
        }
        else if (mapNumber == 2){
            goldToWin = 3;
            return map_2;
        }
        else if(mapNumber == 3){
            goldToWin = 3;
            return map_3;
        }
        else{
            System.out.println("Invalid map number, map 1 will be chosen by default");
            return map_1;
        }
    }

    public int getGoldToWin(){
        return goldToWin;
    }


    public char[][] loadMapFromFile() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the file path: ");
        String filePath = scanner.nextLine();

        try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
            String line;
            char[][] map = new char[100][];
            int rowIndex = 0;

            // Read the file line by line
            while ((line = reader.readLine()) != null) {
                if (line.startsWith("win")) {
                    // Extract the win number
                    String[] parts = line.split(" ");
                    goldToWin = Integer.parseInt(parts[1]);

                } else if (line.startsWith("#")) {
                    // Process map rows starting with '#'
                    map[rowIndex++] = line.toCharArray();
                    while ((line = reader.readLine()) != null) {
                        map[rowIndex++] = line.toCharArray();
                    }
                }
            }

            // Resize the map to the actual number of rows
            char[][] resizedMap = new char[rowIndex][];
            System.arraycopy(map, 0, resizedMap, 0, rowIndex);
            return resizedMap;
        } catch (IOException e) {
            System.out.println("Error loading the map file: " + e.getMessage());
            return null;
        }
    }



}

