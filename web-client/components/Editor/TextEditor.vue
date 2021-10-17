<template>
  <div class="d-flex flex flex-column">
    <div class="flex flat justify-space-between">
      <v-btn :class="{ 'primary': editor.isActive({ textAlign: 'left' }) }"
             v-on:click="editor.chain().setTextAlign('left').focus().run()">
        <v-icon>mdi-format-align-left</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive({ textAlign: 'center' }) }"
             v-on:click="editor.chain().setTextAlign('center').focus().run()">
        <v-icon>mdi-format-align-center</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive({ textAlign: 'right' }) }"
             v-on:click="editor.chain().focus().setTextAlign('right').focus().run()">
        <v-icon>mdi-format-align-right</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive({ textAlign: 'justify' }) }"
             v-on:click="editor.chain().focus().setTextAlign('justify').focus().run()">
        <v-icon>mdi-format-align-justify</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive('bold') }" v-on:click="editor.chain().toggleBold().focus().run()">
        <v-icon>mdi-format-bold</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive('italic') }" v-on:click="editor.chain().toggleItalic().focus().run()">
        <v-icon>mdi-format-italic</v-icon>
      </v-btn>
      <v-btn :class="{ 'primary': editor.isActive('underline') }"
             v-on:click="editor.chain().toggleUnderline().focus().run()">
        <v-icon>mdi-format-underline</v-icon>
      </v-btn>
      <v-btn v-on:click="$refs.uploaderIm.click();" class="px-0 py-0">
        <v-icon>mdi-image</v-icon>
      </v-btn>
      <v-btn v-on:click="$refs.uploaderVid.click();" class="px-0 py-0">
        <v-icon>mdi-video</v-icon>
      </v-btn>
      <input ref="uploaderIm" v-show="false" type="file" accept="image/*" v-on:change="handleFile"/>
      <input ref="uploaderVid" v-show="false" type="file" accept="video/*" v-on:change="handleFile"/>
    </div>
    <div>
      <label class="d-block" v-on:click="editor.chain().focus()">Enter your text below</label>
      <hr>
      <editor-content class="mt-5" :editor="editor"/>
    </div>
  </div>
</template>

<script>
import {Editor, EditorContent} from '@tiptap/vue-2'
import StarterKit from '@tiptap/starter-kit'
import {mapState, mapMutations, mapActions} from "vuex";
import Image from '@tiptap/extension-image'
import TextAlign from '@tiptap/extension-text-align'
import Underline from '@tiptap/extension-underline'

export default {
  name: "Editor",
  components: {
    EditorContent,
  },

  data() {
    return {
      editor: null,
      items: [
        { title: 'Dashboard', icon: 'mdi-view-dashboard' },
        { title: 'Photos', icon: 'mdi-image' },
        { title: 'About', icon: 'mdi-help-box' },
      ],
      right: null,
    }
  },
  computed: {
    ...mapState('posts', ['posts']),
    ...mapState("files", ["uploadPromise"]),
  },
  methods: {
    ...mapMutations('files', ['setType']),
    ...mapMutations('posts', ["setPosts"]),
    ...mapMutations('textEditor', ['setTextContent']),
    ...mapActions("files", ["createFileUploadTask"]),

    async handleFile(event) {
      const file = event.target.files[0];
      if (!file) return;

      const form = new FormData();
      form.append("mediaFile", file);
      form.append("fileType", event.path[0].accept.split('/')[0])
      this.createFileUploadTask({form});

      if (!this.uploadPromise) return;

      this.editor.chain().focus().setImage({src: `http://localhost:5000/api/files/` + await this.uploadPromise}).run()
    }
  },
  async fetch() {
    this.editor = new Editor({
      extensions: [
        StarterKit,
        Image,
        TextAlign.configure({
          types: ['heading', 'paragraph'],
        }),
        Underline
      ],
      editorProps: {
        attributes: {
          class: 'flex px-2',
          style: 'min-height: 500px; border-left: 2px solid black; border-right: 2px solid black'
        },
      },
      onUpdate: () => {
        this.setTextContent({content: this.editor.getHTML()});
      },
    })
  },

  beforeDestroy() {
    this.editor.destroy()
  },
}
</script>

<style lang="scss">
.ProseMirror {
  padding-top: 8px;
  padding-bottom: 50px;

  p {
    margin: 0;
  }

  img {
    width: 600px;
    display: block;
    margin: auto;
  }
}
</style>
