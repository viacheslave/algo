package com.vzh.leetcode;

import java.util.Objects;
import java.util.PriorityQueue;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

/*
 * Problem: https://leetcode.com/problems/process-tasks-using-servers/
 * Submission: https://leetcode.com/submissions/detail/589552278/
 */
public class P1882 {
  class Solution {
    public int[] assignTasks(int[] servers, int[] tasks) {
      var busy = new PriorityQueue<Task>();

      var free = new PriorityQueue<Server>(
        IntStream.range(0, servers.length)
          .mapToObj(i -> new Server(i, servers[i]))
          .collect(Collectors.toList()));

      int[] ans = new int[tasks.length];
      int taskId = 0;
      int time = 0;

      while (taskId < tasks.length) {
        // release servers which time if expired
        while (busy.peek() != null && busy.peek().time <= time) {
          var server = busy.poll();
          free.add(new Server(server.serverId, server.weight));
        }

        // release one free server
        if (free.size() == 0) {
          var server = busy.poll();
          free.add(new Server(server.serverId, server.weight));
          time = server.time;
          continue;
        }

        // add multiple tasks at once
        while (taskId <= time) {
          if (taskId == tasks.length)
            break;

          var endTime = time + tasks[taskId];
          var server = free.poll();
          if (server == null)
            break;

          busy.add(new Task(taskId, server.id, server.weight, endTime));
          ans[taskId] = server.id;

          taskId++;
        }

        time++;
      }

      return ans;
    }

    public class Task implements Comparable<Task> {
      public int id;
      public int serverId;
      public int weight;
      public int time;

      public Task(int id, int serverId, int weight, int time) {
        this.id = id;
        this.serverId = serverId;
        this.weight = weight;
        this.time = time;
      }

      @Override
      public int compareTo(Task o) {
        if (this.time == o.time)
          return this.id - o.id;
        return this.time - o.time;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Task task = (Task) o;
        return id == task.id && serverId == task.serverId && weight == task.weight && time == task.time;
      }

      @Override
      public int hashCode() {
        return Objects.hash(id, serverId, weight, time);
      }
    }

    public class Server implements Comparable<Server> {
      public int id;
      public int weight;

      public Server(int id, int weight) {
        this.id = id;
        this.weight = weight;
      }

      @Override
      public int compareTo(Server o) {
        if (this.weight == o.weight)
          return this.id - o.id;
        return this.weight - o.weight;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Server server = (Server) o;
        return id == server.id && weight == server.weight;
      }

      @Override
      public int hashCode() {
        return Objects.hash(id, weight);
      }
    }
  }
}