

    <template>
      <form @submit.prevent="createTask()">

        <v-text-field type="text" label="Title" variant="outlined" v-model="title"/>  
        <v-textarea label="Description"
            v-model="description" variant="outlined" no-resize></v-textarea>
        <v-btn type="submit" icon="mdi-plus" size="x-small"></v-btn>

      </form>
    </template>

<script setup lang="ts">
import { type TodoStatus, type TodoItem, useTodoStore } from '@/stores/todoStore';
import { ref } from 'vue'

    interface Props {
  status: TodoStatus;
}
const props = defineProps<Props>();
    const title = ref('')
    const description = ref('')
    const store = useTodoStore()
    const createTask = async () => {
      if (title.value === '') return
      if (description.value === '') return
      const item: TodoItem = {
        title: title.value,
        description: description.value,
        status: props.status
      }
      await store.createTask(item)
      await store.getList(props.status)
      title.value = ''
      description.value = ''
    }
</script>