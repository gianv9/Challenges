//import java.util.Scanner;
import java.io.*;
import java.util.Scanner;

class MatrixReader1 {
    public static void main(String[] args){
        System.out.println("Reading some matrixes...\n"+
        "the output is the two matrix and the result of their multiplication\n" +
        "This will be done for each matrix operation possible\n----------------");
        long startTime = System.currentTimeMillis();
        try{
            Scanner reader = new Scanner(new FileReader("INPUTmatrix.txt"));
            // read the number of testcases
            int T = reader.nextInt();
            // the number of matrixes to be created / received. and their orders
            int[][] orders = new int[T][2];
            // array containing the matrixes
            int[][][] matrixes = new int[T][][];
            for (int x = 0; x < T; x++) {
                int row = reader.nextInt();
                int col = reader.nextInt();
                orders[x][0] = row;
                orders[x][1] = col;
                System.out.println("Matrix "+ x + "(" +orders[x][0] +"x"+ orders[x][1] + ")" );
                int[][] matrix = new int[row][col];
                for (int i = 0; i < row; i++) {
                    for (int j = 0; j < col; j++) {
                        matrix[i][j] = reader.nextInt();
                        //System.out.print(matrix[i][j] + " ");
                    }
                    //System.out.println("");
                }
                matrixes[x] = matrix;
                //System.out.println("----------");
            }
            reader.close();
            // determine which matrixes can be multiplied
            // this indexes will be the ones used to obtain the matrixes from the
            // matrixes array
            System.out.println("----------");
            for (int i = 0; i < T; i++) {
                for (int j = 0; j < T; j++) {
                    if(orders[i][1] == orders[j][0] && i != j){
                        System.out.println("Matrix " + i + "(" +orders[i][0] +"x"+ orders[i][1]  + ")" + " can be multiplied by Matrix " + j + " " + "(" +orders[j][0] +"x"+ orders[j][1]  + ")");
                        int[][] matrix1 = matrixes[i];
                        int[][] matrix2 = matrixes[j];
                        System.out.println("Result: ");
                        matrixMultiply(matrix1,matrix2,new int[][]{orders[i],orders[j]});
                    }
                }
            }

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

    public static void matrixMultiply(int[][] matrix1, int[][] matrix2, int[][] orders){
            long startTime = System.currentTimeMillis();
            //matrix1 columns
            for (int i = 0; i < orders[0][0]; i++) {
                // go through the rows of matrix1 as much times as columns there are in
                // matrix2
                for(int x = 0; x < orders[1][1]; x++){
                    int sumaNuevoElemento = 0;
                    //matrix1 rows
                    for (int j = 0; j < orders[0][1]; j++) {
                        sumaNuevoElemento += matrix1[i][j]*matrix2[j][x];
                    }
                    System.out.print(sumaNuevoElemento + "\t");
                }
                System.out.println("");
            }
            long stopTime = System.currentTimeMillis();
            long elapsedTime = stopTime - startTime;
            System.out.println("Running Time: " + elapsedTime + "Ms");
    }
}
/*
10: New Line Feed (NL)
13: Carriage Return (CR)
32: Space
 */