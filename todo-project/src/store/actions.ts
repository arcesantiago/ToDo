import type { ActionContext, ActionTree } from 'vuex'
import type { Mutations } from './mutations';
import type { State } from './state';

export enum ActionTypes {
    GetTodoItems = 'GET_ITEMS'
  }

  type ActionAugments = Omit<ActionContext<State, State>, 'commit'> & {
    commit<K extends keyof Mutations>(
      key: K,
      payload: Parameters<Mutations[K]>[1]
    ): ReturnType<Mutations[K]>
  }

  const sleep = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));

  export type Actions = {
    [ActionTypes.GetTodoItems](context: ActionAugments): void
  }

export const actions: ActionTree<State, State> & Actions = {
    async [ActionTypes.GetTodoItems]({ commit }) {
  
      await sleep(1000)
  

    }
  }