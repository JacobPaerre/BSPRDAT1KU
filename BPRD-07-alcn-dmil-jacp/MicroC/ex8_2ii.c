void main() {
    int arr[3];
    arr[3] = {1, 2, 3};
    int i;
    i = 0;
    int res;
    res = ++arr[++i];
    print res[0];
    print res[1];
    print res[2];
}