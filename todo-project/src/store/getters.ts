import type { GetterTree } from 'vuex'
import { TodoStatus, type State } from './state'

export type Getters = {
  completedCount(state: State): number
  totalCount(state: State): number
}

export const getters: GetterTree<State, State> & Getters = {
  completedCount(state) {
    return state[TodoStatus.Completed].filter(i => i.status).length
  },
  totalCount(state) {
    return state[TodoStatus.Pending].length + state[TodoStatus.Completed].length
  }
}