import java.sql.*;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;

public class Test {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ArrayList<Student> coll = new ArrayList<>();
        Connection conn = null;
        Statement stmt = null;
        ResultSet rs=null;
        try {
            // Load the JDBC driver
            Class.forName("com.mysql.cj.jdbc.Driver");

            // Connect to the database
            conn = DriverManager.getConnection("jdbc:mysql://localhost/students", "username", "password");

            // Create a statement
            stmt = conn.createStatement();

            while (true) {
                System.out.println("=====  学生成绩管理系统  =====");
                System.out.println("1. 添加学生信息");
                System.out.println("2. 删除学生信息");
                System.out.println("3. 修改学生信息");
                System.out.println("4. 查询学生信息");
                System.out.println("5. 显示所有学生信息");
                System.out.println("6. 退出学生信息");
                System.out.println("请输入要执行的操作编号：");

                int i = scanner.nextInt();
                if (i == 1) {
                    System.out.println("请输入学号：");
                    int id = scanner.nextInt();
                    System.out.println("请输入姓名：");
                    String name = scanner.next();
                    System.out.println("请输入年龄：");
                    int age = scanner.nextInt();
                    System.out.println("请输入成绩：");
                    int score = scanner.nextInt();

                    // Insert the student into the database
                    String sql = "INSERT INTO student (id, name, age, score) VALUES (" + id + ", '" + name + "', " + age + ", " + score + ")";
                    stmt.executeUpdate(sql);

//                    // Add the student to the collection
//                    Student student = new Student(id, name, age, score);
//                    coll.add(student);
                } else if (i == 2) {
                    System.out.println("请输入删除的学号");
                    int id = scanner.nextInt();

                    // Delete the student from the database
                    String sql = "DELETE FROM student WHERE id = " + id;
                    stmt.executeUpdate(sql);

//                    // Remove the student from the collection
//                    Iterator<Student> iterator = coll.iterator();
//                    while (iterator.hasNext()) {
//                        Student student = iterator.next();
//                        if (student.getId() == id) {
//                            iterator.remove();
//                            System.out.println("删除成功！");
//                            break;
//                        }
//                    }
                } else if (i == 3) {
                    System.out.println("请输入修改的学号");
                    int id = scanner.nextInt();
                } else if (i == 4) {
                    System.out.println("请输入查询的学号");
                    int id = scanner.nextInt();

                    // Search for the student in the database
                    String sql = "SELECT * FROM student WHERE id = " + id;
                     rs = stmt.executeQuery(sql);

                    if (rs.next()) {
                        String sid = rs.getString("id");
                        String name = rs.getString("name");
                        String age = rs.getString("age");
                        String score = rs.getString("score");
                        System.out.println("学号：" + sid + " 姓名：" + name + " 年龄：" + age + " 成绩：" + score);
                    } else {
                        System.out.println("没有找到对应的学生");
                    }
                } else if (i == 5) {
                    String sql = "SELECT * FROM student";
                     rs = stmt.executeQuery(sql);

                    while (rs.next()) {
                        String sid = rs.getString("id");
                        String name = rs.getString("name");
                        String age = rs.getString("age");
                        String score = rs.getString("score");
                        System.out.println("学号：" + sid + " 姓名：" + name + " 年龄：" + age + " 成绩：" + score);
                    }
                } else if (i == 6) {
                    System.out.println("退出程序");
                    break;
                } else {
                    System.out.println("输入有误，请重新输入");
                }
            }
        }catch(Exception e){
            e.printStackTrace();
        }finally{
            if (rs != null) {
                try {
                    stmt.close();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            if (stmt != null) {
                try {
                    stmt.close();
                } catch (Exception e) {
                        e.printStackTrace();
                }
            }
            if (conn != null) {
                try {
                    conn.close();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }

    }
}


