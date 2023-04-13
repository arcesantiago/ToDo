import { defineStore } from 'pinia'
import axios, { type AxiosResponse } from 'axios'

export enum TodoStatus {
    Pending = "pending",
    Completed = "completed"
}

export type TodoItem = {
    id?: number
    title:string;
    description: string
    status: TodoStatus
  }

interface State {
    [TodoStatus.Pending] : TodoItem[];
    [TodoStatus.Completed] : TodoItem[];
}

export const useTodoStore = defineStore('todo', {

  state: (): State => ({
    [TodoStatus.Pending] : [],
    [TodoStatus.Completed] : []
  }),
  getters: {
    completedCount: (state) => state[TodoStatus.Completed].filter(i => i.status).length,
    totalCount: (state) => state[TodoStatus.Pending].length + state[TodoStatus.Completed].length
  },
  actions: {
    async getList (status:TodoStatus) {
      let data: TodoItem[] = []
      await axios.get<TodoItem[]>('http://localhost:3000/api/v1/Tasks/' + status)
    .then(function (response) {
      data = response.data
      console.log(response);
    })
    .catch(function (error) {
      console.log(error);
    })
    debugger;
    this[status] = data
  },
    async createTask (payload: TodoItem) {

      await axios.post('http://localhost:3000/api/v1/Tasks', payload)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    },
    async deleteTask (payload: TodoItem) {
      debugger;
       await axios.delete('http://localhost:3000/api/v1/Tasks/' + payload.id)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
        return;
      });
    },
    async updateTask (payload: TodoItem) {
      debugger;
      await axios.put('http://localhost:3000/api/v1/Tasks/' + payload.id)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
        return;
      });
    }
  }
})