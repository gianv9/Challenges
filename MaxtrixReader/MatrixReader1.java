//import java.util.Scanner;
import java.io.*;
import java.util.Scanner;

class MatrixReader1 {
    public static void main(String[] args){
        long startTime = System.currentTimeMillis();
        try{
            Scanner reader = new Scanner(new FileReader("INPUTmatrix.txt"));
            int T = reader.nextInt();
            for (int x = 0; x < T; x++) {
                int row = reader.nextInt();
                int col = reader.nextInt();
                int[][] matrix = new int[row][col];
                for (int i = 0; i < row; i++) {
                    for (int j = 0; j < col; j++) {
                        matrix[i][j] = reader.nextInt();
                        System.out.print(matrix[i][j] + " ");
                    }
                    System.out.println("");
                }
                System.out.println("----------");
            }
            reader.close();

            long stopTime = System.currentTimeMillis();
            long elapsedTime = stopTime - startTime;
            System.out.println("Running Time: " + elapsedTime + "Ms");
        }
        catch(FileNotFoundException e){
            System.out.println("No se encontro el archivo especificado...");
        }
        // catch(IOException e){
        //     System.out.println("Error de IO...");
        // }
        
    }
}
/*
10: New Line Feed (NL)
13: Carriage Return (CR)
32: Space
 */