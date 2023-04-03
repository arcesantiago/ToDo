import { defineStore } from 'pinia'
import axios from 'axios'
export enum TodoStatus {
    Pending = "pending",
    Completed = "completed"
}

export type TodoItem = {
    id: number
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
    getList:() => axios.get('http://localhost:5041/api/v1/Tasks/GetTaskList')
    .then(function (response) {
      // manejar respuesta exitosa
      console.log(response);
    })
    .catch(function (error) {
      // manejar error
      console.log(error);
    }),
    createTask (payload: TodoItem) {
        this[payload.status].push(payload)
    },
    deleteTask (payload: TodoItem) {
        this[payload.status] = this[payload.status].filter(element => element !== payload)
    },
    updateTask (payload: TodoItem) {
        this[payload.status] = this[payload.status].filter(
            (todo) => todo.id !== payload.id
          );
      
          if(payload.status == TodoStatus.Pending) payload.status = TodoStatus.Completed
      
          else payload.status = TodoStatus.Pending;
            
          this[payload.status].unshift(payload)
    }
  }
})