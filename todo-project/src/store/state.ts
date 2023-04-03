import { reactive } from "vue";

export type TodoItem = {
    id: number
    title:string;
    description: string
    status: TodoStatus
  }
  
  export type State = {
    [TodoStatus.Pending] : TodoItem[];
    [TodoStatus.Completed] : TodoItem[];
  }

  export enum TodoStatus {
    Pending = "pending",
    Completed = "completed"
}

  const defaultVal = {
    [TodoStatus.Pending] : [],
    [TodoStatus.Completed] : []
  }

  export const state: State = reactive<State>(defaultVal);


