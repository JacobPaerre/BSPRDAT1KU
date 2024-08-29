import java.util.Map;

public class Assignment1_14 {
    public static void main(String[] args) {
        Expr e = new Add(new CstI(17), new Var("z"));
        System.out.println(e.toString());

        // (ii)
        Expr e1 = new Mul(new Add(new Sub(new CstI(5), new Sub(new CstI(49), new CstI(17))), new CstI(8)), new CstI(1));
        Expr e2 = new Mul(new Add(new Sub(new CstI(5), new CstI(8)), new CstI(1)), new CstI(0));
        Expr e3 = new Sub(new Mul(new CstI(25), new Var("t")), new CstI(12));

        System.out.println(e1.toString());
        System.out.println(e2.toString());
        System.out.println(e3.toString());

        Expr e4 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));

        System.out.println(e4.simplify().toString()); // should return x :)
    }
}

abstract class Expr {
    public abstract String toString();

    public abstract Expr simplify();

    public abstract int eval(Map<String, Integer> env);
}

class CstI extends Expr {
    int val;

    CstI(int val) {
        this.val = val;
    }

    public String toString() {
        return Integer.toString(val);
    }

    public int eval(Map<String, Integer> env) {
        return val;
    }

    public Expr simplify() {
        return this;
    }
}

class Var extends Expr {
    String str;

    Var(String str) {
        this.str = str;
    }

    public String toString() {
        return str;
    }

    public int eval(Map<String, Integer> env) {
        return env.get(str);
    }

    public Expr simplify() {
        return this;
    }
}

abstract class Binop extends Expr {
    Expr a;
    Expr b;
}

class Add extends Binop {
    public String toString() {
        return "(" + a + " + " + b + ")";
    }

    Add(Expr x, Expr y) {
        this.a = x;
        this.b = y;
    }

    public int eval(Map<String, Integer> env) {
        return a.eval(env) + b.eval(env);
    }

    public Expr simplify() {
        Expr simpleA = a.simplify();
        Expr simpleB = b.simplify();

        if (simpleA instanceof CstI && ((CstI) simpleA).val == 0) {
            return simpleB;
        } else if (simpleB instanceof CstI && ((CstI) simpleB).val == 0) {
            return simpleA;
        }

        return (new Add(simpleA, simpleB)).simplify();
    }
}

class Mul extends Binop {
    public String toString() {
        return "(" + a + " * " + b + ")";
    }

    Mul(Expr x, Expr y) {
        this.a = x;
        this.b = y;
    }

    public int eval(Map<String, Integer> env) {
        return a.eval(env) * b.eval(env);
    }

    public Expr simplify() {
        Expr simpleA = a.simplify();
        Expr simpleB = b.simplify();

        if (simpleA instanceof CstI && ((CstI) simpleA).val == 1) {
            return simpleB;
        } else if (simpleB instanceof CstI && ((CstI) simpleB).val == 1) {
            return simpleA;
        } else if (simpleA instanceof CstI && ((CstI) simpleA).val == 0) {
            return new CstI(0);
        } else if (simpleB instanceof CstI && ((CstI) simpleB).val == 0) {
            return new CstI(0);
        }

        return (new Mul(simpleA, simpleB)).simplify();
    }
}

class Sub extends Binop {
    public String toString() {
        return "(" + a + " - " + b + ")";
    }

    Sub(Expr x, Expr y) {
        this.a = x;
        this.b = y;
    }

    public int eval(Map<String, Integer> env) {
        return a.eval(env) - b.eval(env);
    }

    public Expr simplify() {
        Expr simpleA = a.simplify();
        Expr simpleB = b.simplify();

        if (simpleB instanceof CstI && ((CstI) simpleB).val == 0) {
            return simpleA;
        } else if (a.equals(b)) {
            return new CstI(0);
        }

        return (new Sub(simpleA, simpleB)).simplify();
    }
}
