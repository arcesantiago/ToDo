

    <template>
      <form @submit.prevent="createTask">

        <v-text-field type="text" label="Title" variant="outlined" v-model="title"/>  
        <v-textarea label="Description"
            v-model="description" variant="outlined" no-resize></v-textarea>
        <v-btn type="submit" icon="mdi-plus" size="x-small"></v-btn>

      </form>
    </template>

<script setup lang="ts">
import { ref } from 'vue'
import { useStore } from '@/store'
import type { TodoItem, TodoStatus } from '@/store/state'
import { MutationType } from '@/store/mutations'


    interface Props {
  status: TodoStatus;
}
const props = defineProps<Props>();
    const title = ref('')
    const description = ref('')
    const store = useStore()
    const createTask = () => {
      if (title.value === '') return
      if (description.value === '') return
      const item: TodoItem = {
        id: Math.random() * 10000000000000000,
        title: title.value,
        description: description.value,
        status: props.status
      }
      store.commit(MutationType.CreateItem, item)
      title.value = ''
      description.value = ''
    }
</script>