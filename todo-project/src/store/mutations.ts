import type { MutationTree } from 'vuex'
import { TodoStatus, type State, type TodoItem } from './state'

export enum MutationType {
  CreateItem = 'CREATE_ITEM',
  DeleteItem = 'DELETE_ITEM',
  UpdateItem = 'UPDATE_ITEM'
}

export type Mutations = {
  [MutationType.CreateItem](state: State, item: TodoItem): void,
  [MutationType.DeleteItem](state: State, item: TodoItem): void,
  [MutationType.UpdateItem](state: State, item: TodoItem): void
}

export const mutations: MutationTree<State> & Mutations = {
  [MutationType.CreateItem](state, item) {
    state[item.status].unshift(item)
  },
  [MutationType.DeleteItem](state,item){
    debugger;
    state[item.status] = state[item.status].filter(element => element !== item)
  },
  [MutationType.UpdateItem](state,item){
    state[item.status] = state[item.status].filter(
      (todo) => todo.id !== item.id
    );

    if(item.status == TodoStatus.Pending) item.status = TodoStatus.Completed

    else item.status = TodoStatus.Pending;
      
    state[item.status].unshift(item)
  }
}