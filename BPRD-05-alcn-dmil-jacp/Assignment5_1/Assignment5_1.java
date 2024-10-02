
public class Assignment5_1 {
    public static void main(String[] args) {
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };

        int[] zs = merge(xs, ys);

        for (int i : zs) {
            System.out.print(i + " ");
            // 2 3 3 4 5 7 12
        }
    }

    static int[] merge(int[] xs, int[] ys) {

        int xs_len = xs.length;
        int ys_len = ys.length;
        int[] zs = new int[xs_len + ys_len];

        int i = 0, j = 0, k = 0;
        while (i < xs_len && j < ys_len) {
            if (xs[i] < ys[j]) {
                zs[k] = xs[i];
                i++;
            } else {
                zs[k] = ys[j];
                j++;
            }
            k++;
        }

        // hvis xs er større end ys
        while (i < xs_len) {
            zs[k] = xs[i];
            i++;
            k++;
        }

        // hvis ys er større end xs
        while (j < ys_len) {
            zs[k] = ys[j];
            j++;
            k++;
        }

        return zs;
    }
}